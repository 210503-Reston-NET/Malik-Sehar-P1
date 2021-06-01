using Models;
using System.Collections.Generic;
namespace SBL
{
    public interface ILineItem
    {
        public List<MLineItems> GetAllOrders(int searchedOrdersInStore);
        public void ItemToAddInOrders(MOrders orders);
        public List<MOrders> GetOrdersWithAllLocations();
        List<MOrders> GetOrderByLocationId(int id, string date);
        List<MOrders> GetOrderByCustomerId(int id, string date);
    }
}