using Microsoft.EntityFrameworkCore;
using Models;
namespace SDL
{
    public class ChocolatefactoryContext : DbContext
    {
        //connection needed to pass in connection string 
        protected ChocolatefactoryContext():base(){}
        public ChocolatefactoryContext(DbContextOptions options):base(options){

        }

        //Declaring Entities
        public DbSet<MCustomer> Customers {get; set;}
        public DbSet<MInventory> Inventories {get; set;}
        public DbSet<MLineItems> LineItems {get; set;}
        public DbSet<MOrders> Orders {get; set;}
        public DbSet<MLocation> Locations {get; set;}
        public DbSet<MProduct> Products{get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<MCustomer>().Property(Customer => Customer.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<MInventory>().Property(Inventory => Inventory.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<MLineItems>().Property(LineItems => LineItems.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<MOrders>().Property(order => order.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<MLocation>().Property(Locations => Locations.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<MProduct>().HasAlternateKey(p => p.Barcode);
        }
    }
}