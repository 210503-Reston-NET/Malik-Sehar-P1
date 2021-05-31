using Models;
using System.Collections.Generic;
namespace SBL
{
    public interface IInventory
    {
        List<MInventory> GetInventoryInStore(int id);
        MInventory AddProductInInventory(MInventory mInventory);
        MInventory UpdateInventory(MInventory Inventory);
        MInventory GetInventoryById(int InvId);
        MInventory DeleteInventory(MInventory mInventory);
        MInventory GetProductExitInInventory(string Barcode);
    }
}