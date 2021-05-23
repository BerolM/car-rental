using Domain.Constants;
using Domain.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class AuthController : Controller
    {
        private Application.Services.IAuthenticationService AuthenticationService { get;}
        public AuthController(Application.Services.IAuthenticationService authenticationService)
        {
            AuthenticationService = authenticationService;
        }
        public IActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO user)
        {
            var loginResponse = AuthenticationService.Login(user);
            if (loginResponse.IsSuccess==false)
            {
                ViewBag.Response = Domain.DTOs.Response.Fail(loginResponse.Message);
                return View();
            }

            await HttpContext.SignInAsync(AuthenticationConstants.AuthenticationScheme,
                                          loginResponse.Data,
                                          new AuthenticationProperties());

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(AuthenticationConstants.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDTO user)
        {
            var registerResponse = AuthenticationService.Register(user);
            if (registerResponse.IsSuccess==false)
            {
                ViewBag.Response = Domain.DTOs.Response.Fail(registerResponse.Message);
                user.Password = string.Empty;
                return View(user);
            }

            await base.HttpContext.SignInAsync(AuthenticationConstants.AuthenticationScheme,
                                                registerResponse.Data,
                                                new AuthenticationProperties());

            return RedirectToAction("Index", "Home");


        }
        
    }
}
