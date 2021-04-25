using Application.Services;
using Application.Services.Concrete;
using Domain.DTOs;
using Domain.Entities;
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
    public class VehicleController : Controller
    {
        private IVehicleService VehicleService { get; }
        private IVehicleBrandService VehicleBrandService { get; }
        private IVehicleModelService VehicleModelService { get; }
        private IColorTypeService ColorTypeService { get; }
        private IFuelTypeService FuelTypeService { get; }
        private ITireTypeService TireTypeService { get; }
        private ITransmissionTypeService TransmissionTypeService { get; }
        private IVehicleClassTypeService VehicleClassTypeService { get; }

        public VehicleController(IVehicleService vehicleService,
                                 IVehicleBrandService vehicleBrandService,
                                 IVehicleModelService vehicleModelService,
                                 IVehicleClassTypeService vehicleClassTypeService,
                                 IColorTypeService colorTypeService,
                                 IFuelTypeService fuelTypeService,
                                 ITireTypeService tireTypeService,
                                 ITransmissionTypeService transmissionTypeService
                                 )
        {
            VehicleService = vehicleService;
            VehicleBrandService = vehicleBrandService;
            VehicleModelService = vehicleModelService;
            VehicleClassTypeService = vehicleClassTypeService;
            ColorTypeService = colorTypeService;
            FuelTypeService = fuelTypeService;
            TireTypeService = tireTypeService;
            TransmissionTypeService = transmissionTypeService;
        }
        // GET: VehicleController
        public ActionResult Index()
        {
            VehicleFilter filter = new VehicleFilter();
            var items = VehicleService.Get(filter);
            return View(items);
        }

        // GET: VehicleController/Details/5
        public ActionResult Details(int id)
        {
            var item = VehicleService.GetDetail(id);
            return View(item);
        }

        // GET: VehicleController/Create
        public ActionResult Create()
        {
            SetParametersToViewBag();

            return View();
        }

        // POST: VehicleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehicle vehicle)
        {
            try
            {
                var response = VehicleService.Add(vehicle);
                ViewBag.Response = response;
            }
            catch
            {
                ViewBag.Response = Domain.DTOs.Response.Fail("Bir hata oluştu");
            }
            finally
            {
                SetParametersToViewBag();
            }
            return View();
        }
        
        // GET: VehicleController/Edit/5
        public ActionResult Edit(int id)
        {
            var item = VehicleService.GetById(id);
            SetParametersToViewBag();
            return View(item);
        }

        // POST: VehicleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Vehicle vehicle)
        {
            try
            {
                var response = VehicleService.Update(vehicle);
                ViewBag.Response = response;
            }
            catch
            {
                ViewBag.Response = Domain.DTOs.Response.Fail("Bir hata oluştu");
            }
            finally
            {
                SetParametersToViewBag();
            }
            return View(vehicle);
        }

        // GET: VehicleController/Delete/5
        public ActionResult Delete(int id)
        {
            var item = VehicleService.GetDetail(id);
            return View(item);
        }

        // POST: VehicleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                VehicleService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var item = VehicleService.GetDetail(id);
                return View(item);
            }
        }
        private void SetParametersToViewBag()
        {
            ViewBag.VehicleModels = GetVehicleModels();
            ViewBag.VehicleClassTypes = GetVehicleClassTypes();
            ViewBag.ColorTypes = GetColorTypes();
            ViewBag.FuelTypes = GetFuelTypes();
            ViewBag.TireTypes = GetTireTypes();
            ViewBag.TransmissionTypes = GetTransmissionTypes();
        }
        private List<SelectListItem> GetVehicleModels()
        {
            return VehicleModelService.Get(new VehicleModelFilter()).Select(m => new SelectListItem($"{m.VehicleBrandName} {m.Name}", m.Id.ToString())).ToList();
        }
        private List<SelectListItem> GetVehicleClassTypes()
        {
            return VehicleClassTypeService.Get(new VehicleClassTypeFilter()).Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToList();
        }
        private List<SelectListItem> GetColorTypes()
        {
            return ColorTypeService.Get(new ColorTypeFilter()).Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToList();
        }
        private List<SelectListItem> GetFuelTypes()
        {
            return FuelTypeService.Get(new FuelTypeFilter()).Select(f => new SelectListItem(f.Name, f.Id.ToString())).ToList();
        }
        private List<SelectListItem> GetTireTypes()
        {
            return TireTypeService.Get(new TireTypeFilter()).Select(t => new SelectListItem(t.Name, t.Id.ToString())).ToList();
        }
        private List<SelectListItem> GetTransmissionTypes()
        {
            return TransmissionTypeService.Get(new TransmissionTypeFilter()).Select(t => new SelectListItem(t.Name, t.Id.ToString())).ToList();
        }
    }
}
