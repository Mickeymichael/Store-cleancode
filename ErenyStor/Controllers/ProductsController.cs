using Application.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErenyStor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet]
        public async Task< IActionResult> Get()
        {
            var products = await _productService.GetAllProducts();
            if (products==null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet ("id")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Product product )

        {
            var iscreate = await _productService.CreateProduct(product);
            if (iscreate)
            {
                return NotFound();
            }
            return Ok(product);
        }


        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(Product product)

        {
            var isupdate = await _productService.UpdateProduct(product);
            if (isupdate)
            {
                return NotFound();
            }
            return Ok(product);
        }



        
        [HttpDelete("ProductId")]
        public async Task<IActionResult> Delete(int productId)

        {
            var isDelete = await _productService.DeleteProduct(productId);
            if (isDelete)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
