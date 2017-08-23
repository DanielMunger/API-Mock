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
        public IActionResult GetAll(int? id)
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
            else
            {
                return new ObjectResult(_context.Products.ToList());
            }
        }

        //[HttpGet("{id}", Name = "GetProduct")]
        //public IActionResult GetById(long id)
        //{
        //    var product = _context.Products.FirstOrDefault(t => t.ProductId == id);
        //    if (product == null)
        //    {
               
        //        return NotFound();
        //    }
        //    return new ObjectResult(product);
        //}
    }
}
//public string Get(int? id, string firstName, string lastName, string address)
//{
//    if (id.HasValue)
//        GetById(id);
//    else if (string.IsNullOrEmpty(address))
//        GetByName(firstName, lastName);
//    else
//        GetByNameAddress(firstName, lastName, address);
//}