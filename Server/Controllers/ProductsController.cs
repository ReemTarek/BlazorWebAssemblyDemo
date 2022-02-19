using BlazorWebAssemblyDemo.Services;
using Microsoft.AspNetCore.Mvc;
using BlazorWebAssemblyDemo.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace BlazorWebAssemblyDemo.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _IProducts;
        public ProductsController(IProductsService iProducts)
        {
            _IProducts = iProducts;
        }
        [HttpGet]
        public async Task<List<Products>> Get()
        {
            return await Task.FromResult(_IProducts.GetProducts());
        }

        [HttpPost]
        public void Post(Products product)
        {
            _IProducts.CreateProduct(product);
        }
        [HttpPut]
        public void Put(Products product)
        {
            _IProducts.UpdateProduct(product);
        }

        [HttpPut("{id}")]
        public void PutwithID(int id,Products product)
        {   
            _IProducts.UpdateProductwithID(id,product);
        }
        [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                _IProducts.DeleteProduct(id);
                return Ok();
            }
        }
    
}
