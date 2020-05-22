using System;
using System.Threading.Tasks;
using InstaApi.Web.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InstaApi.Web.Helpers.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class IsLoggedInAttribute : ActionFilterAttribute
    {
        public override async void OnActionExecuting(ActionExecutingContext context)
        {
            var api =  await LoginHelper.GetApi();
            if (!api.IsUserAuthenticated)
            {
                context.HttpContext.Response.Redirect("/auth/index");
            }
            else
            {
                base.OnActionExecuting(context);
            }
        }
    }
}