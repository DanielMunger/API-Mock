using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using API_4TELL.Models;
using System.Linq;

namespace API_4TELL.Controllers

{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ApplicationContext _context;

        public ProductsController(ApplicationContext context)
        {
            _context = context;

            if (_context.Products.Count() == 0)
            {
                _context.Products.Add(new Product(0, "Running Shoes", "Running"));
                _context.Products.Add(new Product(2, "Baseball Bat", "Baseball"));
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetById(long id)
        {
            var item = _context.Products.FirstOrDefault(t => t.ProductId == id);
            if (item == null)
            {
               
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}
