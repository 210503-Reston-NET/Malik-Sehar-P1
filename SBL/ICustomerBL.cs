using System.Collections.Generic;
using Models;
namespace SBL
{
    public interface ICustomerBL
    {
        List<MCustomer> GetAllCustomers();
        MCustomer AddCustomer(MCustomer customer);
        MCustomer searchACustomer(MCustomer customer);
        public MCustomer GetCustomerById(int id);
    }
}