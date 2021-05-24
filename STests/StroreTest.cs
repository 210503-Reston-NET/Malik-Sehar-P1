using System;
using Xunit;
using Models;
namespace StoreTest
{
    public class UnitTest1
    {
        [Fact]
        public void CustomerShouldSetValidData()
        {
            // Arrange 
            string CustomerName = "Sehar";
            MCustomer test = new MCustomer();

            //Act
            test.Name = CustomerName;

            //Assert 
            Assert.Equal(CustomerName, test.Name);
        }
        [Theory]
        // [InlineData("2345678i")]
        // [InlineData("beufkjsdhfkjs1")]
        [InlineData("Sehar Malik")]
        //[Fact]
        public void CustomerShouldNotSetInvalidData(string input)
        {
            //Arrange 
            MCustomer test = new MCustomer();

            //Act & Assert
            Assert.Throws<Exception>(() => test.Name = input);
        }
    }
}
