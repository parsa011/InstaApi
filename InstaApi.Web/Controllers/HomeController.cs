using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstaApi.Common.ViewModels;
using InstaApi.Web.Helper;
using InstaApi.Web.Helpers.Filters;
using InstagramApiSharp;
using Microsoft.AspNetCore.Mvc;

namespace InstaApi.Web.Controllers
{
    [IsLoggedIn]
    public class HomeController : Controller
    {
        [HttpGet(template:"/{userName}")]
        public async Task<IActionResult> Index()
        {
            var api = await LoginHelper.GetApi();
            var inbox = await api.MessagingProcessor 
                .GetDirectInboxAsync(PaginationParameters.MaxPagesToLoad(1));
            var feed = await api.FeedProcessor.GetUserTimelineFeedAsync(PaginationParameters.MaxPagesToLoad(2));
            return View(new IndexViewModel
            {
                Inbox = inbox,
                Feed = feed
            });
        }
    }
}