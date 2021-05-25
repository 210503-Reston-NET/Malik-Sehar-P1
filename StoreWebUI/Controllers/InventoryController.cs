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
            if(listInv != null)
            {
                return View(listInv.Select(pro => new InventoryVM(pro)).ToList());
            }
            return View();
        }

        public void GetNamesOfStoreAndPro(MInventory inventory)
        {
            List<MLocation> mLocation = _iLocationBL.GetAllLocation();
            foreach (MLocation store in mLocation)
            {
                if (store.Id == inventory.StoreId)
                {
                    ViewData["StoreName"] = store.Name;
                }
            }
            //MProduct products = _iproductBL.GetAProduct();
            /*foreach (MProduct pro in products)
            {
                if (pro.Barcode == inventory.ProductId)
                {
                    ViewData["ProductName"] = pro.Name;
                }
            }*/
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
            return View(new InventoryVM(_inventory.GetInventoryById(id)));
        }

        // POST: InventoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,InventoryVM inventoryVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _inventory.UpdateInventory(new MInventory(inventoryVM.Id, inventoryVM.StoreId, inventoryVM.ProdId, inventoryVM.Quantity ));
                    return RedirectToAction("Index", "Location");
                }
                return View();
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
