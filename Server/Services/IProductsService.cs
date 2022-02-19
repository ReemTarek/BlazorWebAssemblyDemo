using BlazorWebAssemblyDemo.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebAssemblyDemo.Services
{
    public interface IProductsService
    {
        List<Products> GetProducts();
        Products CreateProduct(Products product);
        bool UpdateProduct(Products product);
        bool UpdateProductwithID(int Id, Products product);
        bool DeleteProduct(int id);
    }
}
