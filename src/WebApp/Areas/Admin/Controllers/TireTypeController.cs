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
    public class TireTypeController : Controller
    {
        private ITireTypeService TireTypeService { get; }

        public TireTypeController(ITireTypeService tireTypeService)
        {
            TireTypeService = tireTypeService;
        }

        // GET: TireTypeController
        public ActionResult Index()
        {
            TireTypeFilter filter = new TireTypeFilter();
            var items = TireTypeService.Get(filter);
            return View(items);
        }

        // GET: TireTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TireTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TireType tireType)
        {
            try
            {
                var response = TireTypeService.Add(tireType);
                ViewBag.Response = response;
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: TireTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            var item = TireTypeService.GetById(id);
            return View(item);
        }

        // POST: TireTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TireType tireType)
        {
            try
            {
                var response = TireTypeService.Update(tireType);
                ViewBag.Response = response;
                return View(tireType);
            }
            catch
            {
                return View();
            }
        }

        // GET: TireTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            var item = TireTypeService.GetById(id);
            return View(item);
        }

        // POST: TireTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                TireTypeService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
