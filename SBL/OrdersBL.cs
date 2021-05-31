using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL;
namespace SBL
{
    public class OrdersBL : IOrderBL
    {
        private IRepository _irepo;
        public OrdersBL(IRepository repo)
        {
            _irepo = repo;
        }
        public List<MOrders> GetOrderByLocationId(int id)
        {
            return _irepo.GetOrderByLocationId(id);
        }
    }
}
