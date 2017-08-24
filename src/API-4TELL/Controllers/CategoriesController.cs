//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using API_4TELL.Models;
//using System.Diagnostics;
//using API_4TELL.Models.Repositories;

//namespace API_4TELL.Controllers
//{
//    [Route("api/[controller]")]
//    public class CategoriesController : Controller
//    {        

//        private ICategoryRepository categoryRepo;

//        public CategoriesController(ICategoryRepository categoryRepo = null)
//        {
//            if (categoryRepo == null)
//            {
//                this.categoryRepo = new EFCategoryRepository();
//            }
//            else
//            {
//                this.categoryRepo = categoryRepo;
//            }
//        }


//        [HttpGet]
//        public IActionResult GetAll(string categoryName)
//        {
//            if (categoryName != null)
//            {
//                var category = categoryRepo.Categories.FirstOrDefault(t => t.CategoryName == categoryName);
//                if (category == null)
//                {

//                    return NotFound();
//                }
//                return new ObjectResult(category);
//            }
//            else
//            {
//                return new ObjectResult(categoryRepo.Categories.ToList());
//            }
//        }

//        [HttpGet("{name}", Name = "GetProducts")]
//        public IActionResult GetProducts(string name)
//        {
//            var category = categoryRepo.Categories.FirstOrDefault(t => t.CategoryName == name);
//            if (category == null)
//            {

//                return NotFound();
//            }
//            return new ObjectResult(category);
//        }
//    }
//}
