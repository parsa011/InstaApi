using InstaApi.Common.ViewModels.Auth;
using InstaApi.Web.Helper;
using InstagramApiSharp.API;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
                return Redirect($"/{(await _instaApi.GetCurrentUserAsync()).Value.UserName}");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("index", model);
            }
            await LoginHelper.Login(model.UserName, model.Password);
            _instaApi = await LoginHelper.GetApi();
            if (_instaApi == null)
            {
                return View("Index",model);
            }
            return Redirect($"/{(await _instaApi.GetCurrentUserAsync()).Value.UserName}");
        }
    }
}