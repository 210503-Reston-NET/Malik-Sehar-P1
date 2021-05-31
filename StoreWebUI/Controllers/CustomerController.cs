using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBL;
using StoreWebUI.Models;
using Models;

namespace StoreWebUI.Controllers
{
    public class CustomerController : Controller
    {
        // GET: CustomerController
        private ICustomerBL _icustomerBL;
        public CustomerController(ICustomerBL customerBL)
        {
            _icustomerBL = customerBL;
        }
        public ActionResult Index()
        {
            return View(_icustomerBL.GetAllCustomers().Select(cust => new CustomersVM(cust)).ToList());
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult SearchCustomerByPhone()
        {
            return View();
        }
        public ActionResult SearchCustomerByPhone1(CustomersVM customer)
        {
               MCustomer customer1 = new MCustomer(customer.PhoneNum, customer.Password);
               MCustomer customerSearched = _icustomerBL.searchACustomer(customer1);
               return View(new CustomersVM(customerSearched));
            //return RedirectToAction(nameof(Index));
        }
        // GET: CustomerController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomersVM customersVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _icustomerBL.AddCustomer(
                        new MCustomer
                        {
                            Name = customersVM.Name,
                            PhoneNo = customersVM.PhoneNum,
                            Address = customersVM.Address,
                            Password = customersVM.Password
                        });
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            MCustomer toEdit = _icustomerBL.GetCustomerById(id);
            return View(new CustomersVM(toEdit));
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomersVM customersVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _icustomerBL.UpdateCustomer(new MCustomer(customersVM.Id, customersVM.Name, customersVM.PhoneNum, customersVM.Address, customersVM.Password));
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            MCustomer toBeDeleted = _icustomerBL.GetCustomerById(id);
            return View(new CustomersVM(toBeDeleted));
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _icustomerBL.DeleteCustomer(_icustomerBL.GetCustomerById(id));
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
