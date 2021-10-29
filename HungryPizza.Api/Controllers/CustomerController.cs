using AutoMapper;
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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerOrderService _customerOrderService;

        public CustomerController(ICustomerService customerService, ICustomerOrderService customerOrderService)
        {
            _customerService = customerService;
            _customerOrderService = customerOrderService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(CustomerRequest customerRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

                var customerResponse = await  _customerService.CustomerRegister(customerRequest);
                return Ok(customerResponse);
            }
            catch (Exception ex)
            {
                return BadRequest($"{HttpStatusCode.BadRequest}: mensagem de erro: {ex.Message}");
            }
        }

        [HttpGet("Register")]
        public async Task<ActionResult> Select(int customerId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

                var customerResponse = await _customerService.SelectedCustomer(customerId);
                return Ok(customerResponse);
            }
            catch (Exception ex)
            {
                return BadRequest($"{HttpStatusCode.BadRequest}: mensagem de erro: {ex.Message}");
            }
        }

        [HttpGet("MyOrders")]
        public async Task<ActionResult> CustomerOrderList(int customerId, int page = 1)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

                var customerOrderList = await _customerOrderService.CustomerOrderList(customerId, page);
                return Ok(customerOrderList);
            }
            catch (Exception ex)
            {
                return BadRequest($"{HttpStatusCode.BadRequest}: mensagem de erro: {ex.Message}");
            }
        }

    }
}
