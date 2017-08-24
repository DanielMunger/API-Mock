using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API_4TELL.Models;
using System.Diagnostics;

namespace API_4TELL.Controllers
{
    [Route("api")]
    public class ApiController : Controller
    {
        private readonly ApplicationContext _context;

        public ApiController(ApplicationContext context)
        {
            _context = context;
            Product runningShoes = new Product(3, "Running Shoes", "Running");
            Category running = new Category(1, "Running");
            running.Products.Add(runningShoes);
            Product baseballBat = new Product(4, "baseball Bat", "Baseball");
            Category baseball = new Category(2, "Baseball");
            baseball.Products.Add(baseballBat);

            if (_context.Products.Count() == 0)
            {
                _context.Products.Add(runningShoes);
                _context.Products.Add(baseballBat);
                _context.SaveChanges();
            }
            if (_context.Categories.Count() == 0)
            {
                _context.Categories.Add(baseball);
                _context.Categories.Add(running);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IActionResult GetAll(int? id, string categoryName)
        {
            if (id.HasValue)
            {
                var product = _context.Products.FirstOrDefault(t => t.ProductId == id);
                if (product == null)
                {

                    return NotFound();
                }
                return new ObjectResult(product);
            }
            if (categoryName != null)
            {
                var category = _context.Categories.FirstOrDefault(t => t.CategoryName == categoryName);
                if (category == null)
                {
                    return NotFound();
                }
                return new ObjectResult(category.Products);
            }
            else
            {
                return new ObjectResult(_context.Products.ToList());
            }
        }
       
    }
}
