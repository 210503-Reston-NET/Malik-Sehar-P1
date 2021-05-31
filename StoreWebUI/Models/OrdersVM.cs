using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebUI.Models
{
    public class OrdersVM
    {
        public OrdersVM(MOrders mOrders)
        {
            Id = mOrders.Id;
            Total = mOrders.Total;
            date = mOrders.date;
            customer = mOrders.customer;
            StoreFront = mOrders.storeFronts;
        }
        public int Id { get; set; }
        public double Total { get; set; }
        public DateTime date { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public List<MLineItems> lineItems { get; set; }
        public MCustomer customer { get; set; }
        public MLocation StoreFront { get; set; }
    }
}
