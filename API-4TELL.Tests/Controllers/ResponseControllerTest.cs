using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_4TELL.Controllers;
using API_4TELL.Models;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using API_4TELL.Models.Repositories;

namespace API_4TELL.Tests.Controllers
{
    public class ResponseControllerTest
    {
        Mock<IProductRepository> mockProducts = new Mock<IProductRepository>();
        Mock<ICategoryRepository> mockCategories = new Mock<ICategoryRepository>();

        private void DbSetup()
        {
            Product runningShoes = new Product(1, "Running Shoes", "Running");
            Product runningShorts = new Product(2, "Running Shorts", "Running");
            Product sweatshirt = new Product(3, "Sweatshirt", "Running");
            Product baseballCleats = new Product(4, "Baseball Cleats", "Baseball");
            Product baseballMitt = new Product(5, "Baseball Mitt", "Baseball");
            Product baseballBat = new Product(6, "Baseball Bat", "baseball");
            mockProducts.Setup(m => m.Products).Returns(new Product[]
            {
                runningShoes, runningShorts, sweatshirt, baseballCleats, baseballMitt, baseballBat                                
            }.AsQueryable());

            mockCategories.Setup(m => m.Categories).Returns(new Category[]
            {
                new Category {CategoryId = 1, CategoryName = "Running", Products =
                    {
                        runningShoes, runningShorts, sweatshirt
                    }
                },
                new Category {CategoryId = 2, CategoryName = "Baseball", Products =
                    {
                        baseballBat, baseballCleats, baseballMitt
                    }
                }            
            }.AsQueryable());
        }

        

    
    }
}


