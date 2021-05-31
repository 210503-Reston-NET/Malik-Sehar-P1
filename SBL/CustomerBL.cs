using Models;
using System.Collections.Generic;
using SDL;
using System.Linq;
namespace SBL
{
    public class CustomerBL:ICustomerBL
    {
        private IRepository _repo;
        public CustomerBL(IRepository repo){
            _repo = repo;
        }
        public List<MCustomer> GetAllCustomers(){
            return _repo.GetAllCustomers();
        }
        public MCustomer AddCustomer(MCustomer customer){
            return _repo.AddCustomer(customer);
        }

        public MCustomer searchACustomer(MCustomer customer)
        {
            return _repo.searchACustomer(customer);
        }

        public MCustomer GetCustomerById(int id)
        {
            return _repo.GetCustomerById(id);
        }
    }
}