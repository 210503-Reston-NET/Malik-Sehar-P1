using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using StoreWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBL;
using LearnASPNETCoreMVCWithRealApps.Helpers;

namespace StoreWebUI.Controllers
{
    public class ProductsController : Controller
    {
        private IProductBL _IproductBL;
        private IInventory _inventory;
        private ILineItem _iLineItem;
        private MOrders _openOrder;
        // GET: ProductsController
        public ProductsController( IProductBL productBL, IInventory inventory, ILineItem lineItem)
        {
            _IproductBL = productBL;
            _inventory = inventory;
            _iLineItem = lineItem;
        }

        public ActionResult Index(int id)
        {
            List<MInventory> listInv = _inventory.GetInventoryInStore(id);
            return View(listInv.Select(pro => new InventoryVM(pro)).ToList());
        }
        public ActionResult Order(int id)
        {
            MInventory inventory = _inventory.GetInventoryById(id);
            MProduct productSelected = _IproductBL.searchAProduct(inventory.ProductId);
            if (inventory.Quantity > 0)
            {
                _openOrder = new MOrders
                {
                    Total = 0,
                    CustID = 1,
                    LocationID = inventory.StoreId
                };
                if (SessionHelper.GetObjectFromJson<List<MLineItems>>(HttpContext.Session, "cart") == null)
                {
                    List<MLineItems> cart = new List<MLineItems>();
                    MLineItems lineI = new MLineItems(productSelected.Barcode, 1);
                    lineI.product = productSelected;
                    cart.Add(lineI);
                    _openOrder.lineItems = cart;
                    _openOrder.UpdateTotal();
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                }
                else
                {
                    List<MLineItems> cart = SessionHelper.GetObjectFromJson<List<MLineItems>>(HttpContext.Session, "cart");
                    int index = isExist(inventory.ProductId);
                    if (index != -1)
                    {
                        _openOrder.lineItems = cart;
                        cart[index].Quantity++;
                        _openOrder.UpdateTotal();
                    }
                    else
                    {
                        MLineItems lineI = new MLineItems(productSelected.Barcode, 1);
                        lineI.product = productSelected;
                        _openOrder.lineItems = cart;
                        _openOrder.UpdateTotal();
                        cart.Add(lineI);
                    }
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "order", _openOrder);
                return RedirectToAction("Checkout", new { checkout = false });
            }
            else
            {
                return RedirectToAction("Index", new { id = inventory.StoreId });
            }

        }
        private int isExist(string id)
        {
            List<MLineItems> cart = SessionHelper.GetObjectFromJson<List<MLineItems>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].product.Barcode.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        [Route("remove/{id}")]
        public IActionResult Remove(string id)
        {
            List<MLineItems> cart = SessionHelper.GetObjectFromJson<List<MLineItems>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index", "Location");
        }
        public ActionResult Checkout(bool checkout)
        {
            var cart = SessionHelper.GetObjectFromJson<List<MLineItems>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            var order = SessionHelper.GetObjectFromJson<MOrders>(HttpContext.Session, "order");
            if (cart == null)
            {
                return View();
            }
                ViewBag.order = order;
                var grandTotal = cart.Sum(item => item.product.Price * item.Quantity);
                ViewBag.Total = grandTotal;
                order.Total = grandTotal;
            if (cart != null && checkout == false)
            {
                return View();
            }
            else
            {
                _iLineItem.ItemToAddInOrders(order);
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Location");
            }
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
                    if(_inventory.GetProductExitInInventory(productVM.Barcode) == null)
                    {
                        _inventory.AddProductInInventory(new MInventory
                        {
                            StoreId = id,
                            ProductId = productVM.Barcode
                        });
                        if (_IproductBL.searchAProduct(productVM.Barcode) == null)
                        {
                            _IproductBL.AddAProduct(new MProduct
                            {
                                Barcode = productVM.Barcode,
                                Name = productVM.Name,
                                Price = productVM.Price
                            });
                        }
                        return RedirectToAction("Index", "Inventory", new { id });
                    }
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
        public ActionResult ViewAllProducts()
        {
            return View(_IproductBL.GetAllProducts().Select(product => new ProductVM(product)).ToList());
        }
        // GET: ProductsController/Delete/5
        public ActionResult Delete(string barcode)
        {
            return View(new ProductVM(_IproductBL.GetProductById(barcode)));
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                if (_inventory.GetProductExitInInventory(id) == null)
                {
                       _IproductBL.DeleteAProduct(_IproductBL.GetProductById(id));
                        return RedirectToAction(nameof(ViewAllProducts));
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
