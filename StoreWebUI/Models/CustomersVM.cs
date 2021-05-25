using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebUI.Models
{
    public class CustomersVM
    {
        public CustomersVM(MCustomer mcustomer)
        {
            Id = mcustomer.Id;
            Name = mcustomer.Name;
            PhoneNum = mcustomer.PhoneNo;
            Address = mcustomer.Address;
            Password = mcustomer.Password;
        }
        public CustomersVM() { }
        public int Id { get; set;  }

        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNum { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
