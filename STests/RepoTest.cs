using Microsoft.EntityFrameworkCore;
using Xunit;
using SDL;
using Models;

namespace STests
{
    /// <summary>
    /// When Unit test DB Note that you need to install the Mcrosoft.EntityFrameworkCore.Sqlite
    /// package.Sqlite has features that lets you create an in memory rdb.
    /// </summary>
    public class RepoTest
    {
        private readonly DbContextOptions<ChocolatefactoryContext> options;
        //Xunit creates new instances of classes, you need to make sure that you seed your DB
        //for each class
        public RepoTest(){
            options = new DbContextOptionsBuilder<ChocolatefactoryContext>().UseSqlite("Filename=Test.db").Options;
            seed();
        }
        [Fact]
        public void GetAllCustomerShouldReturnAllCustomer(){
            using(var context = new ChocolatefactoryContext(options)){
                //Arrange
                IRepository _repo = new RepoDB(context);
                //Act
                var customers = _repo.GetAllCustomers();
                //Assert
                Assert.Equal(2, customers.Count);
            }
        }
        private void seed(){
            //this is an example of a using block
            using(var context = new ChocolatefactoryContext(options)){
                context.Database.EnsureCreated();
                context.Database.EnsureDeleted();
                context.Customers.AddRange(
                    new MCustomer{
                        Id = 1,
                        Name = "Sehar",
                        PhoneNo = "345678",
                        Address = "Reno"
                    },
                    new MCustomer{
                        Id = 2,
                        Name = "Mehak",
                        PhoneNo = "456789",
                        Address = "Fernley"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}