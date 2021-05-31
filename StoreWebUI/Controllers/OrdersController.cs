using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using StoreWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBL;
namespace StoreWebUI.Controllers
{
    public class OrdersController : Controller
    {
        private ILineItem _lineItems;
        private ICustomerBL _iCustomerBL;
        private ILocationBL _ilocationBL;
        private IInventory _inventory;
        private IProductBL _iProduct;
        public OrdersController(ILineItem ilineItems, ICustomerBL customerBL, ILocationBL locationBL, IInventory iinventory, IProductBL productBL)
        {
            _lineItems = ilineItems;
            _iCustomerBL = customerBL;
            _ilocationBL = locationBL;
            _inventory = iinventory;
            _iProduct = productBL;
        }
        // GET: OrdersController
        public ActionResult Index()
        {
            List<MOrders> orderList = _lineItems.GetOrdersWithAllLocations();
            Console.WriteLine(orderList.ToString());
            return View();
        }
        public ActionResult ViewOrders(int id)
        {
            List<MOrders> orderList = _lineItems.GetOrderByLocationId(id);
            if(orderList.Count > 0)
            {
                foreach (MOrders order in orderList)
                {
                    if (order.lineItems != null)
                    {
                       ViewBag.Order = order;
                       return View(order.lineItems.Select(order => new LineItemVM(order)).ToList());
                    }
                }
            }
            return RedirectToAction("Index", "Location");
        }
        public ActionResult ViewOrdersByCustomerId(int id)
        {
            return View();
        }
        // GET: OrdersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
