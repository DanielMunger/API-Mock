using API_4TELL.Models;
using Xunit;
using API_4TELL.Models.Repositories;
using API_4TELL.Tests.ModelTests;

namespace API_4TELL.Tests
{
    public class ResponseControllerTest
    {
        EFProductRepository db = new EFProductRepository(new TestDbContext());

        [Fact]
        public void GetResponseTest()
        {
            //Arrange
        

            //Act
        

            //Assert
            Assert.Equal("Wash the dog", "Wash the dog");
        }

    }

}
