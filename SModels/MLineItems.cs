using System.Collections.Generic;
namespace Models
{
    public class MLineItems
    {
        public MLineItems(string proId, int orderId, int quantity){
            this.ProId = proId;
            this.OrderID = orderId;
            this.Quantity = quantity;
        }
        public MLineItems(string proId, int quantity){
            this.ProId = proId;
            this.Quantity = quantity;
        }
        public MLineItems(){}
        public int Id {get; set;}
        public string ProId {get; set;}
        public int OrderID {get; set;}
        public int Quantity {get; set;}
        public List<MOrders> orders {get; set;}
        public MProduct product {get; set;}
        public List<MProduct> products {get; set;}
        public List<MLocation> locations {get; set;}
    }
}