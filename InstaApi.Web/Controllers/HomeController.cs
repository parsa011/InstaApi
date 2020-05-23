using System.Linq;
using InstaApi.Common.ViewModels;
using InstaApi.Web.Helper;
using InstaApi.Web.Helpers.Filters;
using InstagramApiSharp;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InstaApi.Web.Controllers
{
    [IsLoggedIn]
    public class HomeController : Controller
    {
        [HttpGet(template: "/{userName}")]
        public async Task<IActionResult> Index()
        {
            var api = await LoginHelper.GetApi();
            var inbox = await api.MessagingProcessor
                .GetDirectInboxAsync(PaginationParameters.MaxPagesToLoad(1));
            var feed = await api.FeedProcessor.GetUserTimelineFeedAsync(PaginationParameters.MaxPagesToLoad(2));
            var stories = await api.StoryProcessor.GetStoryFeedAsync();
            return View(new IndexViewModel
            {
                Inbox = inbox,
                Feed = feed,
                Stories = stories
            });
        }

        [HttpGet]
        public async Task<IActionResult> GeUserStoryFeed(string userId)
        {
            var api = await LoginHelper.GetApi();
            var stories = await api.StoryProcessor.GetUserStoryFeedAsync(long.Parse(userId));
            return View(stories.Value);
        }
    }
}