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
                Product newProduct = new Product(3, "Running Shoes", "Running");
                Category newCategory = new Category(1, "Running");
                newCategory.Products.Add(newProduct);
                _context.Categories.Add(newCategory);
                
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        [HttpGet("{name}", Name = "GetCategory")]
        public IActionResult GetByName(string name)
        {
            var category = _context.Categories.FirstOrDefault(t => t.CategoryName == name);
            if (category == null)
            {

                return NotFound();
            }
            return new ObjectResult(category);
        }
    }
}
