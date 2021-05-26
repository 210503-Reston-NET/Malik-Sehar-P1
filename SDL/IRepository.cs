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
        List<MProduct> GetProductsInventory(MInventory inventory);
        MCustomer searchACustomer(MCustomer customer);
        List<MOrders> GetAllOrders(MLocation searchedOrdersInStore);
        public void ItemToAddInOrders(MOrders orders);
        List<MInventory> GetInventoryInStore(int id);
        MInventory AddProductInInventory(MInventory mInventory);
        MInventory UpdateInventory(MInventory inventory);
        MInventory GetInventoryById(int id);
        MInventory DeleteInventory(MInventory mInventory);
        MProduct searchAProduct(string barcode);
        MInventory GetProductExitInInventory(string Barcode);
    }
}