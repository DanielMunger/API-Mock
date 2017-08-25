using API_4TELL.Models;
using Xunit;
using API_4TELL.Models.Repositories;
using API_4TELL.Tests.ModelTests;
using API_4TELL.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API_4TELL.Tests
{
    public class ResponseControllerTest
    {
        EFProductRepository db = new EFProductRepository(new TestDbContext());

        [Fact]
        public void DatabaseTest()
        {
            //Arrange
            ResponseController controller = new ResponseController(db);
            Category baseball = new Category(1, "baseball");
            Product baseballGlove = new Product(1, "Baseball Glove", baseball);
            baseball.Products.Add(baseballGlove);
            
            

            //Act
        

            //Assert
            Assert.Equal("Wash the dog", "Wash the dog");
        }

        [Fact]
        public async void Test()
        {
            // Arrange
            var controller = new ResponseController(db);

            // Act
            var response = await controller.GetData(0,"fakeName") as ObjectResult;

            // Assert
            var value = response.Value as IEnumerable<Product>;

            Assert.Empty(value);
        }

    }

}
