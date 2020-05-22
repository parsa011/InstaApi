using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstaApi.Common.ViewModels.Auth;
using InstaApi.Web.Helper;
using InstagramApiSharp.API;
using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Classes;
using Microsoft.AspNetCore.Mvc;

namespace InstaApi.Web.Controllers
{
    public class AuthController : Controller
    {
        private IInstaApi _instaApi;
        public AuthController()
        {
           

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _instaApi = await LoginHelper.GetApi();
            if (_instaApi != null && _instaApi.IsUserAuthenticated)
            {
                return Content("arreeeeeee");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View("index", model);
            await LoginHelper.Login(model.UserName, model.Password);
            return Content(":D");
        }
    }
}