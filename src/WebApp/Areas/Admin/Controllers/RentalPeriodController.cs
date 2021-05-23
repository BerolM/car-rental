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
    public class RentalPeriodController : Controller
    {
        private IRentalPeriodService RentalPeriodService { get; }

        public RentalPeriodController(IRentalPeriodService rentalPeriodService)
        {
            RentalPeriodService = rentalPeriodService;
        }

        // GET: RentalPeriodController
        public ActionResult Index()
        {
            RentalPeriodFilter filter = new RentalPeriodFilter();
            var items = RentalPeriodService.Get(filter);
            return View(items);
        }

        // GET: RentalPeriodController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RentalPeriodController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RentalPeriod rentalPeriod)
        {
            try
            {
                var response = RentalPeriodService.Add(rentalPeriod);
                ViewBag.Response = response;
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: RentalPeriodController/Edit/5
        public ActionResult Edit(int id)
        {
            var item = RentalPeriodService.GetById(id);
            return View(item);
        }

        // POST: RentalPeriodController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RentalPeriod rentalPeriod)
        {
            try
            {
                var response = RentalPeriodService.Update(rentalPeriod);
                ViewBag.Response = response;
                return View(rentalPeriod);
            }
            catch
            {
                return View();
            }
        }

        // GET: RentalPeriodController/Delete/5
        public ActionResult Delete(int id)
        {
            var item = RentalPeriodService.GetById(id);
            return View(item);
        }

        // POST: RentalPeriodController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                RentalPeriodService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}