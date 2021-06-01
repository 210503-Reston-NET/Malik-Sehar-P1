using Models;
using System.Collections.Generic;
namespace SDL
{
    public interface IRepository
    {
        //Location Operations
        MCustomer AddCustomer(MCustomer customer);
        List<MLocation> GetAllLocation();
        MLocation GetAStore(MLocation location);
        MLocation AddStore(MLocation location);
        //Inventory Operations
        List<MInventory> GetInventoryInStore(int id);
        MInventory UpdateInventory(MInventory inventory);
        MInventory GetInventoryById(int id);
        MInventory DeleteInventory(MInventory mInventory);
        //Products Operations
        List<MProduct> GetAllProductss();
        MProduct GetAProduct(MProduct product);
        MInventory AddProductInInventory(MInventory mInventory);
        List<MInventory> GetProductInStock(MLocation mLocation);
        MProduct UpdateProduct(MProduct product);
        MProduct AddProduct(MProduct product);
        MProduct searchAProduct(string barcode);
        MInventory GetProductExitInInventory(string Barcode);
        MProduct GetProductById(string Barcode);
        MProduct DeleteAProduct(MProduct mProduct);
        //All Customer Operations
        List<MCustomer> GetAllCustomers();
        public MCustomer GetCustomerById(int id);
        MCustomer UpdateCustomer(MCustomer customer);
        MCustomer searchACustomer(MCustomer customer);
        MCustomer DeleteCustomer(MCustomer mCustomer);
        //All Methods to Get Orders List
        List<MOrders> GetOrdersWithAllLocations();
        List<MLineItems> GetAllOrders(int searchedOrdersInStore);
        List<MOrders> GetOrderByLocationId(int id);
        public void ItemToAddInOrders(MOrders orders);
        List<MOrders> GetOrderByCustomerId(int id);


    }
}