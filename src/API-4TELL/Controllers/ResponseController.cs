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
        [HttpGet]
        public IActionResult GetData(int? productId, string categoryName = "all")
        {
            if (productId.HasValue)
            {
                var product = productRepo.Products.FirstOrDefault(t => t.ProductId == productId);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            if(categoryName != null)
            {
                var products = productRepo.Products.Where(t => t.Category == categoryName);
                return Ok(products);
            }  
            else
            {
                return NotFound();
            }          

        }

    }
}