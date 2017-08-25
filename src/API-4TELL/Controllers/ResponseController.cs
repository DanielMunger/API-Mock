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
using API_4TELL.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API_4TELL.Controllers
{
    [Route("api")]
    public class ResponseController : ApiController
    {
        private ICategoryRepository categoryRepo;
        private IProductRepository productRepo;
        public ResponseController(IProductRepository productRepo = null)
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
        // TODO:
        //
        // Add error handling to catch incorrect queries. 
        // 
        // 
        [HttpGet]
        public async Task<IActionResult> GetData(int? productId, string categoryName)
        {
            if (productId.HasValue)
            {
                var product = productRepo.Products
                    .Include(c => c.Category)
                    .Where(p => p.ProductId == productId)
                    .ToList();
                                                 
                if (product == null)
                {
                    return NotFound();
                }              
                return Ok(product);
            }
            if(categoryName != null)
            {
                var products = productRepo.Products
                    .Where(t => t.Category.CategoryName == categoryName)                    
                    .ToList();
                return Ok(products);
            }  
            else
            {                
                return NotFound();
            }          

        }

    }
}