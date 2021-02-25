using Business.Abstract;
using Core.Utilities.Results.Concrate;
using Entities.Concrate;
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
            string fileExtension = carImage.ImagePath.Substring(carImage.ImagePath.IndexOf("."), carImage.ImagePath.Length - carImage.ImagePath.IndexOf("."));
            if ((fileExtension == ".jpg" || fileExtension == ".png" || fileExtension == ".png"))
            {
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
                            carImage.ImagePath = carImageName;
                        }

                    }
                }
            }
            var result = _carImageService.Add(carImage);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
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
    }
}
