using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using Application.Services.Concrete;
using Application.Services;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {//IoC=Inversion of Control
        //Dependency Injection
        private readonly ILogger<HomeController> _logger;
        private readonly IVehicleBrandService _service;

        public HomeController(ILogger<HomeController> logger,IVehicleBrandService vehicleBrandService)
        {
            _logger = logger;
            _service = vehicleBrandService;
        }

        public IActionResult Index()
        {
            string serviceName = _service.GetName();
            ViewBag.ServiceName = serviceName;

            return View();
        }

        public IActionResult Privacy()
        {
            string serviceName = _service.GetName();
            ViewBag.ServiceName = serviceName;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
