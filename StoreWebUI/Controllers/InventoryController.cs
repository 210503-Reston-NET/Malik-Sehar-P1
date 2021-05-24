using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using SBL;
using StoreWebUI.Models;
using System.Collections.Generic;
using System.Linq;

namespace StoreWebUI.Controllers
{
    public class InventoryController : Controller
    {
        private IInventory _inventory;
        private ILocationBL _iLocationBL;
        private IProductBL _iproductBL;
        public InventoryController(IInventory inventory, ILocationBL ilocationBL, IProductBL productBL)
        {
            _inventory = inventory;
            _iLocationBL = ilocationBL;
            _iproductBL = productBL;
        }
        // GET: InventoryController
        public ActionResult Index(int id)
        {
            List<MInventory> listInv = _inventory.GetInventoryInStore(id);
            /*foreach (MInventory inv in listInv)
            {
                List<MProduct> products = _inventory.GetProductsInventory(inv);

                return View(products.Select(pro => new ProductVM(pro)).ToList());
            }*/
            return View(listInv.Select(pro => new InventoryVM(pro)).ToList());
        }

        // GET: InventoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InventoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InventoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductVM productVM)
        {
            try
            {
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: InventoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InventoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,InventoryVM inventoryVM)
        {
            try
            {

                return RedirectToAction("Products", "Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: InventoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InventoryController/Delete/5
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
