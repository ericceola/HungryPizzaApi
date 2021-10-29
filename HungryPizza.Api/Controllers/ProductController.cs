using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces;
using HungryPizza.Domain.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HungryPizza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(ProductRequest productRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

                var response = await _productService.ProductRegister(productRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"{HttpStatusCode.BadRequest}: mensagem de erro: {ex.Message}");
            }
        }

        [HttpGet("List")]
        public async Task<ActionResult> List()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

                var response = await _productService.ListAsync();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"{HttpStatusCode.BadRequest}: mensagem de erro: {ex.Message}");
            }
        }
    }
}
