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
            OrderId = mLineItems.OrderID;
            Quantity = mLineItems.Quantity;
        }
        public int Id { get; set; }
        public string ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
    }
}
