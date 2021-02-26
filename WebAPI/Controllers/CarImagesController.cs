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

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        private string _carImagePathNoName = StorageFilePath.GetPathCarImages();
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        public IActionResult Add(CarImage carImage)
        {
            ImageSave(carImage);
            if (CheckIfImageFile(carImage.ImagePath))
            {
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
        [HttpPost("addbatch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult AddBatch(IFormFile[] imageFile, CarImage carImage)
        {
            ImageBatchSave(imageFile, carImage);
            if (imageFile.Any(p => CheckIfImageFile(p.FileName) == CheckIfImageFile(p.FileName)))
            {
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
        #region Methods
        private void ImageSave(CarImage carImage)
        {
            string fileExtension = carImage.ImagePath.Substring(carImage.ImagePath.IndexOf("."), carImage.ImagePath.Length - carImage.ImagePath.IndexOf("."));
            string carImageName = Guid.NewGuid().ToString() + fileExtension;
            string carImagePathAndName = _carImagePathNoName + carImageName;
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
                    }
                }
            }
        }
        private async void ImageBatchSave(IFormFile[] formFiles, CarImage carImage)
        {
            string[] savedImageUrls = new string[formFiles.Length];
            for (int i = 0; i < formFiles.Length; i++)
            {
                string fileExtension = Path.GetExtension(formFiles[i].FileName);
                string carImageName = Guid.NewGuid().ToString() + fileExtension;
                string carImagePathAndName = _carImagePathNoName + carImageName;
                StreamWriter streamWriter = new StreamWriter(carImagePathAndName);
                if (System.IO.File.Exists(savedImageUrls[i]))
                {
                    if (string.IsNullOrEmpty(savedImageUrls[i]) == false)
                    {
                        using (FileStream source = System.IO.File.Open(savedImageUrls[i], FileMode.Open))
                        {
                            await formFiles[i].CopyToAsync(streamWriter.BaseStream);
                            source.Flush();
                            source.Dispose();
                            carImage.ImagePath = carImageName;
                        }
                    }
                }
            }

        }
        private bool CheckIfImageFile(string imagePath)
        {
            var extension = imagePath.Substring(imagePath.IndexOf("."), imagePath.Length - imagePath.IndexOf("."));

            bool result = (extension == ".jpg" || extension == ".jpeg" || extension == ".png");
            if (!result) return false;

            return true;
        }
        #endregion


    }
}
