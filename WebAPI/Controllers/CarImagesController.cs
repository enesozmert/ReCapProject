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
using System.Net.Http.Headers;
using static Core.Utilities.File.FileUtilities;
using Core.Utilities.File.Concrete;

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
            var imageSave = new NormalImageSave();
            _carImageService.ImageSaveBase(imageSave);
            var result = _carImageService.Add(carImage);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //#region FormFile
        [HttpPost("addformfile")]
        public IActionResult AddBatch([FromForm] CarImage carImage)
        {
            var imageSave = new FormFileImageSave();
            _carImageService.ImageSaveBase(imageSave);
            var result = _carImageService.AddFormFile(carImage);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("addformfilebatch")]
        public IActionResult AddFormFileBatch([FromForm] CarImage carImage)
        {
            var imageSave = new FormFilesImageSave();
            _carImageService.ImageSaveBase(imageSave);
            var result = _carImageService.AddFormFileBatch(carImage);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //#endregion
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
        //token süresi ile image sil
        //bellek , disk
        [HttpGet("view")]
        //[Route("api/Temp/{dataImagePath}")]
        public IActionResult View(int id)
        {         
            var imageSave = new NormalImageSave();
            _carImageService.ImageSaveBase(imageSave);
            var result = _carImageService.View(id, _env.WebRootPath);
            if (result.Success == true)
            {
                string fileExtension = result.Data.Name.Substring(result.Data.Name.IndexOf("."), result.Data.Name.Length - result.Data.Name.IndexOf("."));
                return File(result.Data, @"image/" + fileExtension.Replace(".", ""));
            }
            return BadRequest(result);

        }
        #region Methods


        #endregion


    }
}
