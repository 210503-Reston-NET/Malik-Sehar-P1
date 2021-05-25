using Models;
using System.Collections.Generic;
namespace SBL
{
    public interface IInventory
    {
        List<MProduct> GetProductsInventory(MInventory inventory);
        List<MInventory> GetInventoryInStore(int id);
        MInventory AddProductInInventory(MInventory mInventory);
        MInventory UpdateInventory(MInventory Inventory);
        MInventory GetInventoryById(int InvId);
    }
}