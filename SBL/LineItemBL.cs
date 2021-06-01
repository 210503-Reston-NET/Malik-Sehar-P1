using Models;
using SDL;
using System;
using System.Collections.Generic;

namespace SBL
{
    public class LineItemBL : ILineItem
    {
        private IRepository _repo;
        public LineItemBL(IRepository repo){
            _repo = repo;
        }

        public List<MLineItems> GetAllOrders(int searchedOrdersInStore)
        {
            return _repo.GetAllOrders(searchedOrdersInStore);
        }

        public List<MOrders> GetOrderByCustomerId(int id, string date)
        {
            return _repo.GetOrderByCustomerId(id,date);
        }

        public List<MOrders> GetOrderByLocationId(int id, string date)
        {
            return _repo.GetOrderByLocationId(id,date);
        }

        public List<MOrders> GetOrdersWithAllLocations()
        {
           return _repo.GetOrdersWithAllLocations();
        }

        public void ItemToAddInOrders(MOrders orders){
            _repo.ItemToAddInOrders(orders);
        }
    }
}