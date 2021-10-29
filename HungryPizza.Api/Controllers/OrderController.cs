using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces;
using HungryPizza.Domain.Interfaces.IService;
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
    public class OrderController : ControllerBase
    {
        private readonly ICustomerOrderService _customerOrderService;
   
        public OrderController(ICustomerOrderService customerOrderService)
        {
            _customerOrderService = customerOrderService;
          
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(CustomerOrderRequest customerOrderRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

                var response = await _customerOrderService.CustomerOrderRegister(customerOrderRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"{HttpStatusCode.BadRequest}: mensagem de erro: {ex.Message}");
            }
        }
    }
}
