using Application.Services;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]/[action]")]
    public class VehicleBrandController : Controller
    {
        private IVehicleBrandService VehicleBrandService { get;}
        public VehicleBrandController(IVehicleBrandService vehicleBrandService)
        {
            VehicleBrandService = vehicleBrandService;
        }

        // GET: VehicleBrandController
        public ActionResult Index()
        {
            VehicleBrandFilter filter = new VehicleBrandFilter();
            var items = VehicleBrandService.Get(filter);
            return View(items);
        }

        // GET: VehicleBrandController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehicleBrandController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleBrandController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleBrand vehicleBrand)
        {
            try
            {
                VehicleBrandService.Add(vehicleBrand);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleBrandController/Edit/5
        public ActionResult Edit(int id)
        {
            var item = VehicleBrandService.GetById(id);
            return View(item);
        }

        // POST: VehicleBrandController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VehicleBrand vehicleBrand)
        {
            try
            {
                VehicleBrandService.Update(vehicleBrand);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleBrandController/Delete/5
        public ActionResult Delete(int id)
        {
            var item = VehicleBrandService.GetById(id);
            return View(item);
        }

        // POST: VehicleBrandController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                VehicleBrandService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
