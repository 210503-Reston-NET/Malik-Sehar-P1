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

        public List<MOrders> GetAllOrders(MLocation searchedOrdersInStore)
        {
            return _repo.GetAllOrders(searchedOrdersInStore);
        }
        public void ItemToAddInOrders(MOrders orders){
            _repo.ItemToAddInOrders(orders);
        }
    }
}