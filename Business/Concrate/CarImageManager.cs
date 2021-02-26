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
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage)
        {
            carImage.Date = DateTime.Now;
            //carImage.ImagePath = CheckIfCarImageOfImage(carImage.ImagePath);
            var result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImage.CarID), CheckIfCarImageOfImageExtension(carImage));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageOfImageDelete(carImage), CheckIfCarImageOfImageExtension(carImage));
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
        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var getAllbyCarIdResult = _carImageDal.GetAll(p => p.CarID == carId);
            if (getAllbyCarIdResult.Count == 0)
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage> { new CarImage { ImagePath = FilePath._carImageNameDefault } });
            }

            return new SuccessDataResult<List<CarImage>>(getAllbyCarIdResult);
        }
        #region BusinessMethod
        private IResult CheckIfCarImageLimitExceded(int carID)
        {
            var result = _carImageDal.GetAll(p => p.CarID == carID);
            if (result.Count > 4)
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
        private IResult CheckIfCarImageOfImageExtension(CarImage carImage)
        {
            if (carImage.ImagePath != null)
            {
                string fileExtension = carImage.ImagePath.Substring(carImage.ImagePath.IndexOf("."), carImage.ImagePath.Length - carImage.ImagePath.IndexOf("."));
                if (!(fileExtension == ".jpg" || fileExtension == ".png" || fileExtension == ".png"))
                {
                    return new ErrorResult();
                }
            }
            return new SuccessResult();
        }
        private IResult CheckIfCarImageOfImageUpload(CarImage carImage)
        {
            var imagePath = _carImageDal.Get(p => p.CarID == carImage.CarID).ImagePath;
            string path = FilePath._carImagePathNoName + imagePath;
            if (!string.IsNullOrEmpty(imagePath))
            {
                if (File.Exists(path) == true)
                {
                    File.Delete(path);
                    BusinessRules.Run(CheckIfCarImageOfImageExtension(carImage));
                    return new SuccessResult();
                }
            }
            return new ErrorResult(Messages.CarImagesUpdateExceded);
        }
        private IResult CheckIfCarImageOfImageDelete(CarImage carImage)
        {
            var imagePath = _carImageDal.Get(p => p.CarID == carImage.CarID).ImagePath;
            string path = FilePath._carImagePathNoName + imagePath;
            if (string.IsNullOrEmpty(imagePath) == false)
            {
                if (File.Exists(path) == true)
                {
                    File.Delete(path);
                    return new SuccessResult();
                }
            }
            return new ErrorResult(Messages.CarImagesDeleteExceded);
        }
        private IResult CheckIfCarImageOfImageSave(CarImage carImage)
        {
            string fileExtension = carImage.ImagePath.Substring(carImage.ImagePath.IndexOf("."), carImage.ImagePath.Length - carImage.ImagePath.IndexOf("."));
            string carImageName = Guid.NewGuid().ToString() + fileExtension;
            string carImagePathAndName = FilePath._carImagePathNoName + carImageName;
            StreamWriter streamWriter = new StreamWriter(carImagePathAndName);
            if (System.IO.File.Exists(carImage.ImagePath))
            {
                if (string.IsNullOrEmpty(carImage.ImagePath) == false)
                {
                    using (FileStream source = System.IO.File.Open(carImage.ImagePath, FileMode.Open))
                    {
                        source.CopyTo(streamWriter.BaseStream);
                        source.Flush();
                        source.Dispose();
                        carImage.ImagePath = carImageName;
                        return new SuccessResult();
                    }
                }
            }
            return new ErrorResult();
        }
    }
    #endregion
}
