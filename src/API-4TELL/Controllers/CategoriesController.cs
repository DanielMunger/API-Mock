using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API_4TELL.Models;
using System.Diagnostics;
using API_4TELL.Models.Repositories;

namespace API_4TELL.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {

        private ICategoryRepository categoryRepo;      

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
        public IActionResult GetAll(string categoryName)
        {
            if (categoryName != null)
            {
                switch (categoryName.ToLower())
                {
                    case "all":
                        return Ok(categoryRepo.Categories.ToList());

                    case "baseball":
                        var baseballList = categoryRepo.Categories.ToList();
                        return Ok(baseballList.Where(c => c.CategoryName.ToLower() == "baseball").ToList());

                    case "running":
                        var runningList = categoryRepo.Categories.ToList();
                        return Ok(runningList.Where(c => c.CategoryName.ToLower() == "running").ToList());
                    default:
                        return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }

        //[HttpGet("{name}", Name = "GetProducts")]
        //public IActionResult GetProducts(string name)
        //{
        //    var category = categoryRepo.Categories.FirstOrDefault(t => t.CategoryName == name);
        //    if (category == null)
        //    {

        //        return NotFound();
        //    }
        //    return new ObjectResult(category);
        //}
    }
}
