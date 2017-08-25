using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using API_4TELL.Models;
using System.Linq;
using API_4TELL.Models.Repositories;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAll()
        {
           
            var products = productRepo.Products
                .Include(c => c.Category)                    
                .ToList();
            if (products.Count == 0)
            {
                return BadRequest("Invalid Query. That Product Id Does Not Exist");
            }
            return Ok(products);
                        
        }
        
    }
}
