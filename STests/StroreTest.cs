using System;
using Xunit;
using Models;
namespace StoreTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("Auryn")]
        [InlineData("abCed.Jr")]
        [InlineData("Shin Jong Ou")]
        [InlineData("Something-hyphen")]
        public void NameShouldSetValidData(string input)
        {
            MCustomer test = new MCustomer();

            test.Name = input;

            Assert.Equal(input, test.Name);
        }

       /* [Theory]
        [InlineData("Aur!yn0")]
        public void NameShouldNotSetInvalidData(string input)
        {
            MCustomer test = new MCustomer();

            Assert.Throws<Exception>(() => test.Name = input);
        }
       
        [Fact]
        public void NameShouldNotBeEmpty()
        {
            MCustomer test = new MCustomer();
            Assert.Throws<Exception>(() => test.Name = "");
        }*/
    }
}
