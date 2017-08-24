using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using API_4TELL.Models;
using System.Linq;
using API_4TELL.Models.Repositories;

namespace API_4TELL.Controllers

{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private IProductRepository productRepo;

        public ProductsController(IProductRepository productRepo = null)
        {
            if (productRepo == null)
            {
                this.productRepo = new EFProductRepository();
            }
            else
            {
                this.productRepo = productRepo;
            }
        }

        [HttpGet]
        public IActionResult GetAll(int? id)
        {
            if (id.HasValue)
            {
                var product = productRepo.Products.FirstOrDefault(t => t.ProductId == id);
                if (product == null)
                {

                    return NotFound();
                }
                return new ObjectResult(product);
            }
            else
            {
                return new ObjectResult(productRepo.Products.ToList());
            }
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetProduct(long id)
        {
            var product = productRepo.Products.FirstOrDefault(t => t.ProductId == id);
            if (product == null)
            {

                return NotFound();
            }
            return new ObjectResult(product);
        }
    }
}
