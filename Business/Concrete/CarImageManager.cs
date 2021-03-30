using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constant;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.CancellationToken;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Business;
using Core.Utilities.File;
using Core.Utilities.File.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrate;
using DataAccess.Abstract;
using Entities.Concrete;
using Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using static Core.Utilities.File.FileUtilities;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ImageSaveBase _imageSaveBase;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [SecuredOperation("product.add,admin")]
        public IResult Add(CarImage carImage)
        {
            carImage.Date = DateTime.Now;
            foreach (var item in _imageSaveBase.Save(new FormFileProp { Name = FileUtilities.NameGuid(), NewPath = StorageFilePath.GetPathCarImages(), OldPath = carImage.ImagePath }))
            {
                carImage.ImagePath = item;
                _carImageDal.Add(carImage);
                //carImage.ImagePath = CheckIfCarImageOfImage(carImage.ImagePath);
                var result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImage.CarID), CheckIfCarImageOfImageExtension(item));
                if (result != null)
                {
                    return result;
                }

            }

            return new SuccessResult(Messages.CarImageAdded);
        }
        [SecuredOperation("product.add,admin")]
        public IResult AddFormFile(CarImage carImage)
        {
            carImage.Date = DateTime.Now;
            foreach (var item in _imageSaveBase.Save(new FormFileProp { Name = FileUtilities.NameGuid(), NewPath = StorageFilePath.GetPathCarImages(), FormFile = carImage.ImageFile }))
            {
                carImage.ImagePath = item;
                _carImageDal.Add(carImage);
                var result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImage.CarID), CheckIfCarImageOfImageExtension(item));
                if (result != null)
                {
                    return result;
                }
            }
            return new SuccessResult(Messages.CarImageAdded);
        }
        //[CancellationTokenAspect]
        [SecuredOperation("admin")]
        public IResult AddFormFileBatch(CarImage carImage)
        {
            var files = _imageSaveBase.Save(new FormFileProp { Name = "burayaneyazarsanyaz", NewPath = StorageFilePath.GetPathCarImages(), FormFiles = carImage.ImageFiles.ToArray() });
            foreach (var item in files)
            {
                _carImageDal.Add(new CarImage { CarID = carImage.CarID, ImagePath = item, Date = DateTime.Now });
                var result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImage.CarID), CheckIfCarImageOfImageExtension(item));
                if (result != null)
                {
                    return result;
                }
            }
            return new SuccessResult(Messages.CarImageAdded);
        }
        [SecuredOperation("admin")]
        public IResult Delete(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageOfImageDelete(carImage), CheckIfCarImageOfImageExtension(carImage.ImagePath));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }
        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _carImageDal.GetAll(p => p.ImagePath == null);
            if (result != null)
            {
                result = new List<CarImage> { new CarImage { ImagePath = FilePath._carImageNameDefault } };
            }
            return new SuccessDataResult<List<CarImage>>(result);
        }
        [CacheAspect]
        public IDataResult<CarImage> GetById(int id)
        {
            var result = _carImageDal.Get(p => p.ID == id);
            if (result.ImagePath == null)
            {
                result.ImagePath = FilePath._carImageNameDefault;
                return new SuccessDataResult<CarImage>(result);
            }
            return new SuccessDataResult<CarImage>(result);
        }
        [SecuredOperation("admin")]
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
            if (getAllbyCarIdResult.Count > 0)
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage> { new CarImage { CarID = carId, Date = DateTime.Now, ImagePath = FilePath._carImageNameDefault } });
            }
            return new SuccessDataResult<List<CarImage>>(getAllbyCarIdResult);
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(CarImage carImage)
        {
            throw new NotImplementedException();
        }
        public IDataResult<FileStream> View(int id, string url)
        {
            FileStream stream = null;
            var dataImageName = _carImageDal.Get(p => p.ID == id)?.ImagePath == null ? "RentACarImageDefault.jpg" : _carImageDal.Get(p => p.ID == id)?.ImagePath;
            if (System.IO.File.Exists(url + @"\Temp\" + dataImageName) == false)
            {
                _imageSaveBase.Save(new FormFileProp { Name = dataImageName.Substring(0, dataImageName.IndexOf(".")), NewPath = url + @"\Temp\", OldPath = StorageFilePath.GetPathCarImages() + dataImageName });
                stream = System.IO.File.Open(url + @"\Temp\" + dataImageName, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            else
            {
                stream = System.IO.File.Open(url + @"\Temp\" + dataImageName, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            return new SuccessDataResult<FileStream>(stream);
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
            if (carImage.Date != DateTime.Now)
            {
                return new ErrorResult(Messages.CarImageDateExceded);
            }
            return new SuccessResult();
        }

        public static IResult CheckIfCarImageOfImageExtension(string imagePath)
        {
            var extension = imagePath.Substring(imagePath.IndexOf("."), imagePath.Length - imagePath.IndexOf("."));

            bool result = (extension == ".jpg" || extension == ".jpeg" || extension == ".png");
            if (!result) return new ErrorResult();

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

        public IResult ImageSaveBase(ImageSaveBase imageSaveBase)
        {
            _imageSaveBase = imageSaveBase;
            return new SuccessResult();
        }
    }
    #endregion
}
