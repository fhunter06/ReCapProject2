﻿using Business.Abstract;
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
    public class CustomersController : ControllerBase
    {
        ICustomersService _customersService;
            public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customersService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _customersService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        /*******************************************************************/

        [HttpPost("add")]
        public IActionResult Add(Customers customers)
        {
            var result = _customersService.Add(customers);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Customers customers)
        {
            var result = _customersService.Update(customers);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Customers customers)
        {
            var result = _customersService.Delete(customers);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}