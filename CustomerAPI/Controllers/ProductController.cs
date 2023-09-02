using CustomerAPI.Authentication;
using CustomerAPI.Models;
using CustomerAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
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

        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (!AuthenticationService.IsAuthenticated(HttpContext.Request))
            {
                return Unauthorized();
            }
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }           

            try
            {
                
                return Ok(await _productService.AddProduct(product));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            if (!AuthenticationService.IsAuthenticated(HttpContext.Request))
            {
                return Unauthorized();
            }
           
            try
            {

                return Ok(await _productService.GetProductsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
