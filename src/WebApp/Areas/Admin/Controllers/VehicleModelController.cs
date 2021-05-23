using Application.Services;
using Domain.Constants;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = AuthenticationConstants.AuthenticationScheme,
               Roles = AuthenticationConstants.OperationClaims.AdminStr)]
    public class VehicleModelController : Controller
    {
        private IVehicleBrandService VehicleBrandService { get; }
        private IVehicleModelService VehicleModelService { get; }

        public VehicleModelController(IVehicleBrandService vehicleBrandService, IVehicleModelService vehicleModelService)
        {
            VehicleBrandService = vehicleBrandService;
            VehicleModelService = vehicleModelService;
        }
        // GET: VehicleModelController
        public ActionResult Index()
        {
            VehicleModelFilter filter = new VehicleModelFilter();
            var items = VehicleModelService.Get(filter);
            return View(items);
        }

        // GET: VehicleModelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehicleModelController/Create
        public ActionResult Create()
        {
            ViewBag.VehicleBrands = GetVehicleBrands();
            return View();
        }

        // POST: VehicleModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleModel vehicleModel)
        {
            try
            {
                var response = VehicleModelService.Add(vehicleModel);
                ViewBag.Response = response;
            }
            catch
            {
                ViewBag.Response = Domain.DTOs.Response.Fail("Bir hata oluştu");
            }
            finally
            {
                ViewBag.VehicleBrands = GetVehicleBrands(); 
            }
            return View();
        }

        private List<SelectListItem> GetVehicleBrands()
        {
            return VehicleBrandService.Get(new VehicleBrandFilter()).Select(b => new SelectListItem(b.Name, b.Id.ToString())).ToList();
        }

        // GET: VehicleModelController/Edit/5
        public ActionResult Edit(int id)
        {
            var item = VehicleModelService.GetById(id);
            ViewBag.VehicleBrands = GetVehicleBrands();
            return View(item);
        }

        // POST: VehicleModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VehicleModel vehicleModel)
        {
            try
            {
                var response = VehicleModelService.Update(vehicleModel);
                ViewBag.Response = response;
            }
            catch
            {
                ViewBag.Response = Domain.DTOs.Response.Fail("Bir hata oluştu");
            }
            finally
            {
                ViewBag.VehicleBrands = GetVehicleBrands();
            }
            return View(vehicleModel);
        }

        // GET: VehicleModelController/Delete/5
        public ActionResult Delete(int id)
        {
            var item = VehicleModelService.GetDetail(id);
            return View(item);
        }

        // POST: VehicleModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                VehicleModelService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var item = VehicleModelService.GetDetail(id);
                return View(item);
            }
        }
    }
}
