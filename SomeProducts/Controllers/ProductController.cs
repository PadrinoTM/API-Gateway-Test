using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SomeProducts;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SomeProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository customerRepository)
        {
            _productRepository = customerRepository;
        }

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<List<Product>>> GetAllCustomers()
        {
            return await _productRepository.GetAllProducts();
        }
    }
}
