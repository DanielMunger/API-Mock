using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API_4TELL.Models;

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
                _context.Categories.Add(new Category { CategoryId = 1, CategoryName = "Running", Products = { newProduct } });
                
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        [HttpGet("{id}", Name = "GetTodo")]
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
