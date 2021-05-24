using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebUI.Models
{
    public class OrdersVM
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public DateTime date { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
    }
}
