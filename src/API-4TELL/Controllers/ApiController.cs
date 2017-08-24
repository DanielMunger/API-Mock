﻿using System;
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

            Category running = new Category(1, "Running");
            Product runningShoes = new Product(3, "Running Shoes", running.CategoryName);
            // runningShoes.Category = running;
            running.Products.Add(runningShoes);


            Category baseball = new Category(2, "Baseball");
            Product baseballBat = new Product(4, "baseball Bat", baseball.CategoryName);
            // baseballBat.Category = baseball;
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
                Debug.WriteLine("baseball "+baseball.CategoryId);
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
                return NotFound();
            }
        }
       
    }
}
