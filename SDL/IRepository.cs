using Models;
using System.Collections.Generic;
namespace SDL
{
    public interface IRepository
    {
        List<MCustomer> GetAllCustomers();
        List<MProduct> GetAllProductss();
        MCustomer AddCustomer(MCustomer customer);
        MProduct AddProduct(MProduct product);
        MProduct GetAProduct(MProduct product);
        List<MLocation> GetAllLocation();
        MLocation GetAStore(MLocation location);
        MLocation AddStore(MLocation location);
        List<MInventory> GetProductInStock(MLocation mLocation);
        MCustomer searchACustomer(MCustomer customer);
        public void ItemToAddInOrders(MOrders orders);
        List<MInventory> GetInventoryInStore(int id);
        MInventory AddProductInInventory(MInventory mInventory);
        MInventory UpdateInventory(MInventory inventory);
        MInventory GetInventoryById(int id);
        MInventory DeleteInventory(MInventory mInventory);
        //Products Operations
        MProduct UpdateProduct(MProduct product);
        MProduct searchAProduct(string barcode);
        MInventory GetProductExitInInventory(string Barcode);
        MProduct GetProductById(string Barcode);
        MProduct DeleteAProduct(MProduct mProduct);
        //All Customer Operations
        MCustomer UpdateCustomer(MCustomer customer);
        MCustomer DeleteCustomer(MCustomer mCustomer);
        //All Methods to Get Orders List
        List<MOrders> GetOrdersWithAllLocations();
        List<MLineItems> GetAllOrders(int searchedOrdersInStore);
        public MCustomer GetCustomerById(int id);
        List<MOrders> GetOrderByLocationId(int id);


    }
}