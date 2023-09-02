using AutoMapper;
using CustomerAPI.Authentication;
using CustomerAPI.DTO;
using CustomerAPI.Models;
using CustomerAPI.Service;
using CustomerAPI.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOrderController : ControllerBase
    {
        private readonly ICustomerOrderInfoService _customerOrderInfoService;      

        public CustomerOrderController(ICustomerOrderInfoService customerOrderInfoService)
        {
            _customerOrderInfoService = customerOrderInfoService;
        }


        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> AddCustomerOrder(CustomerOrderDto customerOrder)
        {
            if (!AuthenticationService.IsAuthenticated(HttpContext.Request))
            {
                return Unauthorized();
            }
            if (customerOrder == null)
            {
                throw new ArgumentNullException(nameof(customerOrder));
            }
           

            try
            {
                await _customerOrderInfoService.CreateCustomerOrder(customerOrder);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetCustomerOrder(Guid customerId)
        {
            if (!AuthenticationService.IsAuthenticated(HttpContext.Request))
            {
                return Unauthorized();
            }

            if (customerId == null)
            {
                throw new ArgumentNullException(nameof(customerId));
            }


            try
            {
               
                return Ok(_customerOrderInfoService.GetAllOrderForCustomer(customerId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
