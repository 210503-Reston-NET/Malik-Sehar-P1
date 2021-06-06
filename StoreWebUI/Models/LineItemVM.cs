using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
namespace StoreWebUI.Models
{
    public class LineItemVM
    {
        public LineItemVM(MLineItems mLineItems)
        {
            Id = mLineItems.Id;
            ProductId = mLineItems.ProId;
            products = mLineItems.product;
            OrderId = mLineItems.OrderID;
            orders = mLineItems.orders;
            customer = mLineItems.customer;
            store = mLineItems.locations;
            Quantity = mLineItems.Quantity;
        }
        public int Id { get; set; }
        public string ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public MProduct products { get; set; }
        public MOrders orders {get; set;}
        public MCustomer customer { get; set; }
        public MLocation store { get; set; }
    }
}
