using System;
using System.Collections.Generic;
namespace Models
{
    public class MOrders
    {
        public MOrders(double total, int custId, int locationId, DateTime dateTime){
            this.Total = total;
            this.CustID = custId;
            this.LocationID = locationId;
            this.date = dateTime;
        }
        public MOrders(DateTime orderdate)
        {
            this.date = orderdate;
        }
        public MOrders(DateTime orderdate, double total) : this(orderdate)
        {
            this.Total = total;
        }
        //Chaining Constructor
        public MOrders(int id, double total, int custId, int locationId, DateTime dateTime) : this(total, custId,locationId, dateTime)
        {
            this.Id = id;
        }
        public MOrders(){}
        public int Id {get; set;}
        public DateTime date {get; set;}
        public double Total {get; set;}
        public int CustID {get; set;} 
        public int LocationID {get; set;}

        public MLocation storeFronts {get; set;}
        public MCustomer customer {get; set;}
        public List<MLineItems> lineItems {get; set;}
        public void UpdateTotal()
        {
            if(this.lineItems is null) this.Total = 0.0;
            double total = 0.0;
            foreach(MLineItems item in this.lineItems)
            {
                total += item.product.Price * item.Quantity;
            }
            this.Total = Math.Round(total, 2);
        }
    }
}