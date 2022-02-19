using BlazorWebAssemblyDemo.Server.Models;
using BlazorWebAssemblyDemo.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAssemblyDemo.Services
{
    public class ProductsService : IProductsService
    {
        private readonly DatabaseContext _context;

        public ProductsService(DatabaseContext context)
        {
            _context = context;
        }

        public List<Products> GetProducts()
        {
           
            return  _context.Products.ToList();
        }

        public Products CreateProduct(Products product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return  product;
        }

        public bool UpdateProduct(Products product)
        {
            var productCheck = _context.Products.Where(x => x.Id == product.Id).FirstOrDefault();
            if (productCheck != null)
            {
                productCheck.ProductName = product.ProductName;
                _context.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }
           public bool UpdateProductwithID(int Id,Products product)
        {
            var productCheck = _context.Products.Where(x => x.Id == Id).FirstOrDefault();
            if (productCheck != null)
            {
                productCheck.ProductName = product.ProductName;
                _context.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool DeleteProduct(int id)
        {
            var productCheck = _context.Products.Where(x => x.Id == id).FirstOrDefault();
            if (productCheck != null)
            {
                _context.Products.Remove(productCheck);
                _context.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

    }
}
