using Business.Abstract;
using Business.Constant;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrate;
using DataAccess.Abstract;
using Entities.Concrate;
using Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrate
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        private string _carImagePathNoName = StorageFilePath.GetPathCarImages();
        private string _carImageNameDefault = "RentACarImageDefault.jpg";
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage)
        {
            carImage.Date = DateTime.Now;
            //carImage.ImagePath = CheckIfCarImageOfImage(carImage.ImagePath);
            var result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImage.CarID), CheckIfCarImageOfImageNew(carImage));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageOfImageDelete(carImage));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            //var result = BusinessRules.Run(GetAllCheckIfCarImageOfImageNull());
            //if (result != null)
            //{
            //    return (IDataResult<List<CarImage>>)result;
            //}
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int CarID)
        {
            var result = BusinessRules.Run(GetCheckIfCarImageOfImageNull());
            if (result != null)
            {
                return (IDataResult<CarImage>)result;
            }
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.CarID == CarID));
        }

        public IResult Update(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImage.CarID), CheckIfCarImageOfImageUpload(carImage));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);

        }
        #region BusinessMethod
        private IResult CheckIfCarImageLimitExceded(int carID)
        {
            var result = _carImageDal.GetAll(p => p.CarID == carID);
            if (result.Count > 6)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }
        private IResult CheckIfAddedDate(CarImage carImage)
        {
            if (carImage.Date != DateTime.Now.Date)
            {
                return new ErrorResult(Messages.CarImageDateExceded);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCarImageOfImageNew(CarImage carImage)
        {
            string fileExtension = carImage.ImagePath.Substring(carImage.ImagePath.IndexOf("."), carImage.ImagePath.Length - carImage.ImagePath.IndexOf("."));
            if (!(fileExtension == ".jpg" || fileExtension == ".png" || fileExtension == ".png"))
            {
                return new ErrorResult();
            }
            string carImagePathAndName = _carImagePathNoName + Guid.NewGuid().ToString() + fileExtension;
            string carImageName = Guid.NewGuid().ToString() + fileExtension;
            StreamWriter streamWriter = new StreamWriter(carImagePathAndName);
            if (string.IsNullOrEmpty(carImage.ImagePath) == false)
            {
                using (FileStream source = File.Open(carImage.ImagePath, FileMode.Open))
                {
                    source.CopyTo(streamWriter.BaseStream);
                }
                carImage.ImagePath = carImageName;
                return new SuccessResult();
            }
            carImage.ImagePath = null;
            return new SuccessResult();
        }
        private IResult CheckIfCarImageOfImageUpload(CarImage carImage)
        {
            if (!string.IsNullOrEmpty(carImage.ImagePath))
            {
                if (File.Exists(_carImagePathNoName + carImage.ImagePath) == true)
                {
                    File.Delete(_carImagePathNoName + carImage.ImagePath);
                    BusinessRules.Run(CheckIfCarImageOfImageNew(carImage));
                    return new SuccessResult();
                }
            }
            return new ErrorResult(Messages.CarImagesUpdateExceded);
        }
        private IResult CheckIfCarImageOfImageDelete(CarImage carImage)
        {
            string path = _carImagePathNoName + carImage.ImagePath;
            if (string.IsNullOrEmpty(carImage.ImagePath) == false)
            {
                if (File.Exists(path) == true)
                {
                    File.Delete(path);
                    return new SuccessResult();
                }
            }
            return new ErrorResult(Messages.CarImagesDeleteExceded);
        }
        private IResult GetAllCheckIfCarImageOfImageNull()
        {
            var result = _carImageDal.GetAll(p => p.ImagePath == null);
            foreach (var res in result)
            {
                if (string.IsNullOrEmpty(res.ImagePath) == false)
                {
                    res.ImagePath = _carImagePathNoName + _carImageNameDefault;
                    return new SuccessResult();
                }
            }
            return new ErrorResult();
        }
        private IResult GetCheckIfCarImageOfImageNull()
        {
            var result = _carImageDal.Get(p => p.ImagePath == null);
            if (!string.IsNullOrEmpty(result.ImagePath))
            {
                result.ImagePath = _carImagePathNoName + _carImageNameDefault;
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
    #endregion
}
