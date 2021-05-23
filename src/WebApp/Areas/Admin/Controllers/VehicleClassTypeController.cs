using Application.Services;
using Domain.Constants;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = AuthenticationConstants.AuthenticationScheme,
               Roles = AuthenticationConstants.OperationClaims.AdminStr)]
    public class VehicleClassTypeController : Controller
    {
        private IVehicleClassTypeService VehicleClassTypeService { get; }
        
        public VehicleClassTypeController(IVehicleClassTypeService vehicleClassTypeService)
        {
            VehicleClassTypeService = vehicleClassTypeService;
        }

        // GET: VehicleClassTypeController
        public ActionResult Index()
        {
            VehicleClassTypeFilter filter = new VehicleClassTypeFilter();
            var items = VehicleClassTypeService.Get(filter);
            return View(items);
        }

        // GET: VehicleClassTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleClassTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleClassType vehicleClassType)
        {
            try
            {
                var response = VehicleClassTypeService.Add(vehicleClassType);
                ViewBag.Response = response;
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleClassTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            var item = VehicleClassTypeService.GetById(id);
            return View(item);
        }

        // POST: VehicleClassTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VehicleClassType vehicleClassType)
        {
            try
            {
                var response = VehicleClassTypeService.Update(vehicleClassType);
                ViewBag.Response = response;
                return View(vehicleClassType);
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleClassTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            var item = VehicleClassTypeService.GetById(id);
            return View(item);
        }

        // POST: VehicleClassTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                VehicleClassTypeService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
