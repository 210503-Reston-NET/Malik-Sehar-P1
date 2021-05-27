using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebUI.Models
{
    public class InventoryVM
    {
        public InventoryVM(MInventory mInventory)
        {
            Id = mInventory.Id;
            StoreId = mInventory.StoreId;
            ProdId = mInventory.ProductId;
            Quantity = mInventory.Quantity;
            Product = mInventory.Products;
            StoreFront = mInventory.StoreFront;
        }

        public InventoryVM(int id, int storeId, string prodId, int quantity)
        {
            Id = id;
            StoreId = storeId;
            ProdId = prodId;
            Quantity = quantity;
        }

        public InventoryVM(int storeId)
        {
            StoreId = storeId;
        }
        public InventoryVM(int storeId, string productId)
        {
            this.StoreId = storeId;
            ProdId = productId;
        }
        
        public InventoryVM()
        {

        }
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string ProdId { get; set; }
        public int Quantity { get; set; }

        public MProduct Product { get;  set; }
        public MLocation StoreFront { get;  set; }
    }
}
