using AutoMapper;
using CustomerAPI.Authentication;
using CustomerAPI.Models;
using CustomerAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public CustomerController(ICustomerService customerService, IMapper mapper)
    {
        _customerService = customerService;
        _mapper = mapper;
    }    
   
    [Route("Add")]
    [HttpPost]
    public async Task<IActionResult> AddCustomer(CustomerDto customer)
    {
        if(!AuthenticationService.IsAuthenticated(HttpContext.Request))
        {
            return Unauthorized();
        }

        if (customer == null)
        {
            throw new ArgumentNullException(nameof(customer));
        }
        var customerEntity = _mapper.Map<Customer>(customer);

        try
        {
            await _customerService.AddCustomer(customer);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
       
    }

    [Route("GetAll")]
    [HttpPost]
    public async Task<IActionResult> GetAllCustomers()
    {
        if (!AuthenticationService.IsAuthenticated(HttpContext.Request))
        {
            return Unauthorized();
        }

        try
        {
            var result = await _customerService.GetCustomersAsync();
            return Ok(_mapper.Map<IEnumerable<CustomerDto>>(result));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }
}