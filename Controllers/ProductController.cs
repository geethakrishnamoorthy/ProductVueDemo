using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductVueDemo.Data;
using ProductVueDemo.Models;

namespace ProductVueDemo.Controllers
{   
    public class ProductController : Controller
    {
        private readonly ProductDb _db;

        public ProductController(ProductDb ProductDb)
        {
            _db = ProductDb;
        }

        [Route("/Product")]
        [HttpGet]
        public IActionResult Get()
        {
            var model = _db.Products;
            return Ok(model);
        }

        [Route("/Product/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var model = _db.Products.Find(id);
            return Ok(model);
        }

        [Route("/Product")]
        [HttpPost]
        public IActionResult Post(Product model)
        {
            //_db.Products.Add(model);
            _db.Set<Product>().Add(model);
            _db.SaveChanges();

            return Ok(model);
        }

        [Route("/Product")]
        [HttpPut]
        public IActionResult Put(Product model)
        {
            var Product = _db.Products.Find(model.Id);
            Product.Name = model.Name;
            Product.Description = model.Description;

            _db.SaveChanges();

            return Ok(model);
        }

        [Route("/Product")]
        [HttpDelete]
        public IActionResult Delete(Product model)
        {
            var Product = _db.Products.Find(model.Id);

            _db.Products.Remove(Product);
            _db.SaveChanges();

            return Ok(model);
        }
    }
}
