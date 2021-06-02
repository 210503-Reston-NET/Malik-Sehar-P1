using Models;
using SDL;
using System.Collections.Generic;
namespace SBL
{
    public class InventoryBL : IInventory
    {
        private IRepository _repo;
        public InventoryBL(IRepository repo){
            _repo = repo;
        }

        public MInventory AddProductInInventory(MInventory mInventory)
        {
            return _repo.AddProductInInventory(mInventory);
        }

        public List<MInventory> GetInventoryInStore(int id)
        {
            return _repo.GetInventoryInStore(id);
        }


        public MInventory UpdateInventory(MInventory Inventory)
        {
            return _repo.UpdateInventory(Inventory);
        }

        public MInventory GetInventoryById(int InvId)
        {
            return _repo.GetInventoryById(InvId);
        }
        public MInventory DeleteInventory(MInventory mInventory)
        {
            return _repo.DeleteInventory(mInventory);
        }

        public MInventory GetProductExitInInventory(int id, string Barcode)
        {
            return _repo.GetProductExitInInventory(id, Barcode);
        }
    }
}