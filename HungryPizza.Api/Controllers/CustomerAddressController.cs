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
    public class CustomerAddressController : ControllerBase
    {
        private readonly ICustomerAddressService _CustomerAddressAervice;
        public CustomerAddressController(ICustomerAddressService CustomerAddressAervice)
        {
            _CustomerAddressAervice = CustomerAddressAervice;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(CustomerAddressRequest customerAddressRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
                    
                var response = await _CustomerAddressAervice.CustomerAddressRegister(customerAddressRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"{HttpStatusCode.BadRequest}: mensagem de erro: {ex.Message}");
            }
        }
    }
}
