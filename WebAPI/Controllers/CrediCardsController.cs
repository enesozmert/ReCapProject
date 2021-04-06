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
    public class CrediCardsController : ControllerBase
    {
        ICreditCardService _creditCardService;

        public CrediCardsController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpPost("add")]
        public IActionResult Add(CreditCard credCard)
        {
            var result = _creditCardService.Add(credCard);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CreditCard credCard)
        {
            var result = _creditCardService.Update(credCard);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("delete")]
        public IActionResult Delete(CreditCard credCard)
        {
            var result = _creditCardService.Delete(credCard);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _creditCardService.GetById(id);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _creditCardService.GetById(userId);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _creditCardService.GetAll();
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
