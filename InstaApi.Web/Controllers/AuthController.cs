using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstagramApiSharp.Classes;
using Microsoft.AspNetCore.Mvc;

namespace InstaApi.Web.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}