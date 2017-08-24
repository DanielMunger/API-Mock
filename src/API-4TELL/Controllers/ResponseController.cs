using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API_4TELL.Models;
using System.Diagnostics;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace API_4TELL.Controllers
{
    [Route("api")]
    public class ResponseController : ApiController
    {
        private readonly ApplicationContext _context;

        public ResponseController(ApplicationContext context)
        {
            _context = context;

            Category running = new Category(1, "Running");
            Product runningShorts = new Product(1, "Running Shorts", running.CategoryName);
            Product runningShoes = new Product(2, "Running Shoes", running.CategoryName);
            running.Products.Add(runningShorts);
            running.Products.Add(runningShoes);


            Category baseball = new Category(2, "Baseball");
            Product baseballBat = new Product(4, "baseball Bat", baseball.CategoryName);
            Product baseballGlove = new Product(5, "baseball Glove", baseball.CategoryName);
            baseball.Products.Add(baseballGlove);
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
                Debug.WriteLine("baseball " + baseball.CategoryId);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IActionResult GetAll(int? productId, string categoryName = "all")
        {
             if (productId.HasValue)
            {
                var product = _context.Products.FirstOrDefault(t => t.ProductId == productId);
                if (product == null)
                {

                    return NotFound();
                }
                return Ok(product);
            }           

            switch (categoryName.ToLower())
            {
                case "all":
                    return Ok(_context.Categories.ToList());

                case "baseball":
                    return Ok(_context.Categories.Where(c => c.CategoryName.ToLower() == "baseball").ToList());

                case "running":
                    return Ok(_context.Categories.Where(c => c.CategoryName.ToLower() == "running").ToList());
                default:
                    return NotFound();


            }

        }

    }
}