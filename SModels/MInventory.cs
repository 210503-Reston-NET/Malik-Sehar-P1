using System.Collections.Generic;

namespace Models
{
    public class MInventory
    {
        public MInventory(int storeId, string ProId, int quantity){
            this.StoreId = storeId;
            this.ProductId = ProId;
            this.Quantity = quantity;
        }

        //constructor chaining
        public MInventory(int id,int storeId, string ProId, int quantity) : this(storeId, ProId, quantity)
        {
            this.Id = id;
        }
        public MInventory(int storeId, string ProId)
        {

        }
        public MInventory (){}
        public int Id {get; set;}
        public int StoreId {get; set;}

        public string ProductId {get; set;}
        public int Quantity {get; set;}
        public MLocation StoreFront { get; set; }
        public MProduct Products { get; set; }
        public List<MLocation> storeFront {get; set;}
        public List<MProduct> products {get; set;}
    }
}