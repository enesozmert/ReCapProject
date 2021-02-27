using Business.Abstract;
using Core.Utilities.Results.Concrate;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.AspNetCore.Hosting;
using Core.Utilities.Results.Abstract;
using System.Threading;
using Core.Utilities.File;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        private readonly IWebHostEnvironment _env;
        private string _carImagePathNoName = StorageFilePath.GetPathCarImages();
        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment env)
        {
            _carImageService = carImageService;
            _env = env;
        }

        [HttpPost("add")]
        public IActionResult Add(CarImage carImage)
        {
            if (FileUtilities.CheckIfImageFile(carImage.ImagePath))
            {
                carImage.ImagePath = FileUtilities.ImageSave(carImage.ImagePath, _carImagePathNoName, FileUtilities.NameGuid());
                var result = _carImageService.Add(carImage);
                if (result.Success == true)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            else
            {
                return BadRequest(new
                {
                    Message = "Geçerli bir resim yükleyiniz.",
                    carImage
                });
            }
        }
        #region FormFile
        [HttpPost("addformfile")]
        public IActionResult AddBatch(IFormFile imageFile, CarImage carImage)
        {
            if (FileUtilities.CheckIfImageFile(imageFile))
            {
                carImage.ImagePath = ImageFromFileSave(imageFile, _carImagePathNoName, FileUtilities.NameGuid());
                var result = _carImageService.Add(carImage);
                if (result.Success == true)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            else
            {
                return BadRequest(new
                {
                    Message = "Geçerli bir resim yükleyiniz.",
                    carImage
                });
            }
        }
        [HttpPost("addfromfilebatch")]
        public IActionResult AddFormFileBatch(List<IFormFile> imageFiles, CarImage carImage)
        {
            if (FileUtilities.CheckIfImageFile(imageFiles))
            {
                IResult result = null;
                foreach (var item in ImageFromFileBatchSave(imageFiles, _carImagePathNoName, FileUtilities.NameGuid()))
                {
                    carImage.ImagePath = item;
                    result = _carImageService.Add(carImage);
                }
                if (result.Success == true)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            else
            {
                return BadRequest(new
                {
                    Message = "Geçerli bir resim yükleyiniz.",
                    carImage
                });
            }
        }
        #endregion
        [HttpPost("update")]
        public IActionResult Update(CarImage carImage)
        {
            var result = _carImageService.Update(carImage);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("view")]
        //[Route("api/Temp/{dataImagePath}")]
        public IActionResult View(int id)
        {
            var result = _carImageService.GetById(id);
            string dataImagePath = result.Data.ImagePath;
            string fileExtension = dataImagePath.Substring(dataImagePath.IndexOf("."), dataImagePath.Length - dataImagePath.IndexOf("."));
            if (result.Success == true)
            {
                if (System.IO.File.Exists(_env.WebRootPath + "/Temp/" + dataImagePath) == false)
                {
                    FileUtilities.ImageSave(_carImagePathNoName + result.Data.ImagePath, _env.WebRootPath + "/Temp/");
                }
                FileStream stream = System.IO.File.Open(_carImagePathNoName + dataImagePath, FileMode.Open);
                return File(stream, @"image/" + fileExtension.Replace(".", ""));
            }

            return BadRequest(result);
        }
        #region Methods

        private string ImageFromFileSave(IFormFile formFile, string newPath, string name = null)
        {
            return FileUtilities.ImageSave(formFile.Name, newPath, name);
        }
        private List<string> ImageFromFileBatchSave(List<IFormFile> formFiles, string newPath, string name = null)
        {
            List<string> list = new List<string>();
            foreach (var formFile in formFiles)
            {
                var result = FileUtilities.ImageSave(formFile.FileName, newPath, name);
                list.Add(result);
            }
            return list;
        }

        #endregion


    }
}
