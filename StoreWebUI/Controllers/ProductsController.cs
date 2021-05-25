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
    public class ProductsController : Controller
    {
        private IProductBL _IproductBL;
        private IInventory _inventory;
        // GET: ProductsController
        public ProductsController( IProductBL productBL, IInventory inventory)
        {
            _IproductBL = productBL;
            _inventory = inventory;
        }
        public ActionResult Index()
        {
            return View(_IproductBL.GetAllProducts().Select(pro => new ProductVM(pro)).ToList());
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();

        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductVM productVM, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _IproductBL.AddAProduct(new MProduct
                    {
                        Barcode = productVM.Barcode,
                        Name = productVM.Name,
                        Price = productVM.Price
                    });
                    _inventory.AddProductInInventory(new MInventory { 
                        StoreId = id,
                        ProductId = productVM.Barcode
                    });
                    return RedirectToAction(nameof(Index), new { id });
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductsController/Edit/5
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

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsController/Delete/5
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
