using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SDL;
using SBL;
using StoreWebUI.Models;
using Models;

namespace StoreWebUI.Controllers
{
    public class LocationController : Controller
    {
        private ILocationBL _LocationBL;
        private IInventory _inventory;
        public LocationController(ILocationBL locationBL, IInventory inventory)
        {
            _LocationBL = locationBL;
            _inventory = inventory;
        }
        // GET: LocationController
        public ActionResult Index()
        {
            return View(_LocationBL.GetAllLocation()
                .Select(location => new LocationVM(location))
                .ToList()
                );
        }

        // GET: LocationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LocationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocationVM locationVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _LocationBL.AddStore(
                        new MLocation { 
                            Name = locationVM.Name,
                            Address = locationVM.Address
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

        // GET: LocationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LocationController/Edit/5
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

        // GET: LocationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LocationController/Delete/5
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
