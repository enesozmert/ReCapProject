using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindeksController : ControllerBase
    {
        IFindexService _findexService;

        public FindeksController(IFindexService findexService)
        {
            _findexService = findexService;
        }

        [HttpPost("add")]
        public IActionResult Add(Findex findexDto)
        {
            var result = _findexService.Add(findexDto);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Findex findexDto)
        {
            var result = _findexService.Update(findexDto);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("delete")]
        public IActionResult Delete(Findex findexDto)
        {
            var result = _findexService.Delete(findexDto);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _findexService.GetById(id);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getuserfindex")]
        public IActionResult GetUserFindex()
        {
            var result = _findexService.GetUserFindex();
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcarfindex")]
        public IActionResult GetCarFindex()
        {
            var result = _findexService.GetCarFindex();
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _findexService.GetAll();
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
