using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API_4TELL.Models;
using System.Diagnostics;
using API_4TELL.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API_4TELL.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {

        private ICategoryRepository categoryRepo;
        private IProductRepository productRepo;

        public CategoriesController(ICategoryRepository categoryRepo = null)
        {
            if (categoryRepo == null)
            {
                this.categoryRepo = new EFCategoryRepository();
            }
            else
            {
                this.categoryRepo = categoryRepo;
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = categoryRepo.Categories                                                     
                .ToList();
            if (categories.Count > 0)
            {
                return Ok(categories);
            }
            else
            {
                return BadRequest();
            }
        }      
    }
}
