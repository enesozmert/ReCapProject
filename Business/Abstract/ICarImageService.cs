using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using static Core.Utilities.File.FileUtilities;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult ImageSaveBase(ImageSaveBase imageSaveBase);
        IDataResult<List<CarImage>> GetAll();
        IResult Add(CarImage carImage);
        IResult AddFormFile(CarImage carImage);
        IResult AddFormFileBatch(CarImage carImage);
        IResult Update(CarImage carImage);
        IResult Delete(CarImage carImage);
        IDataResult<CarImage> GetById(int ID);
    }
}
