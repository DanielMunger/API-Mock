using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API_4TELL.Models;
using System.Diagnostics;

namespace API_4TELL.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ApplicationContext _context;

        public CategoriesController(ApplicationContext context)
        {
            _context = context;

            if (_context.Categories.Count() == 0)
            {

                Product runningShoes = new Product(3, "Running Shoes", "Running");
                Category running = new Category(1, "Running");
                running.Products.Add(runningShoes);
                _context.Categories.Add(running);

                Product baseballBat = new Product(4, "baseball Bat", "Baseball");
                Category baseball = new Category(2, "Baseball");
                baseball.Products.Add(baseballBat);
                _context.Categories.Add(baseball);
                
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IActionResult GetAll(string categoryName)
        {
            if (categoryName != null)
            {
                var category = _context.Categories.FirstOrDefault(t => t.CategoryName == categoryName);
                if (category == null)
                {

                    return NotFound();
                }
                return new ObjectResult(category);
            }
            else
            {
                return new ObjectResult(_context.Categories.ToList());
            }
        }

        //[HttpGet("{name}", Name = "GetCategory")]
        //public IActionResult GetProducts(string name)
        //{
        //    var category = _context.Categories.FirstOrDefault(t => t.CategoryName == name);
        //    if (category == null)
        //    {

        //        return NotFound();
        //    }
        //    return new ObjectResult(category);
        //}
    }
}
