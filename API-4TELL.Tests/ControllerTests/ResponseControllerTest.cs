using API_4TELL.Models;
using Xunit;

namespace API_4TELL.Tests
{
    public class ResponseControllerTest
    {
Mock<IItemRepository> mock = new Mock<IItemRepository>();
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
