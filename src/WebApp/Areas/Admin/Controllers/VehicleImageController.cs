using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Areas.Admin.Models;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]/[action]")]
    public class VehicleImageController : Controller
    {
        private IVehicleImageService VehicleImageService { get; }
        private IVehicleService VehicleService { get; }

        public VehicleImageController(IVehicleImageService vehicleImageService, IVehicleService vehicleService)
        {
            VehicleImageService = vehicleImageService;
            VehicleService = vehicleService;
        }

        private void SetVehicleToViewBag(int vehicleId)
        {
            var vehicle = VehicleService.GetDetail(vehicleId);
            ViewBag.VehicleName = $"{vehicle?.VehicleBrandName} {vehicle?.VehicleModelName}";
            ViewBag.VehicleId = vehicleId;
        }

        // GET: VehicleImageController
        public ActionResult Index(int vehicleId)
        {
            SetVehicleToViewBag(vehicleId);
            var items = VehicleImageService.GetByVehicle(vehicleId);
            return View(items);
        }

        // GET: VehicleImageController/Create
        public ActionResult Create(int vehicleId)
        {
            VehicleImageViewModel model = new VehicleImageViewModel();
            model.VehicleId = vehicleId;
            SetVehicleToViewBag(vehicleId);

            return View(model);
        }

        // POST: VehicleImageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VehicleImageViewModel model)
        {
            try
            {
                VehicleImage vehicleImage = new VehicleImage();
                vehicleImage.VehicleId = model.VehicleId;
                var response = await VehicleImageService.Add(vehicleImage, model.Image);
                ViewBag.Response = response;
            }
            catch
            {
                ViewBag.Response = Domain.DTOs.Response.Fail("Bir hata oluştu");
            }
            finally
            {
                SetVehicleToViewBag(model.VehicleId);
            }
            return View(model);
        }

        // GET: VehicleImageController/Delete/5
        public ActionResult Delete(int id)
        {
            var item = VehicleImageService.GetById(id);
            SetVehicleToViewBag(item.VehicleId);
            return View(item);
        }

        // POST: VehicleImageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var item = VehicleImageService.GetById(id);
            try
            {
                var response = VehicleImageService.Delete(id);
                if (response.IsSuccess)
                    return RedirectToAction(nameof(Index), new { vehicleId = item.VehicleId });
                else
                    ViewBag.Response = response;
            }
            catch
            {
                ViewBag.Response = Domain.DTOs.Response.Fail("Bir hata oluştu");
            }
            finally
            {
                SetVehicleToViewBag(item.VehicleId);
            }
            return View(item);
        }
    }
}