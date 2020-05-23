using InstagramApiSharp.Classes;
using InstagramApiSharp.Classes.Models;

namespace InstaApi.Common.ViewModels
{
    public class IndexViewModel
    {
        public IResult<InstaDirectInboxContainer> Inbox { get; set; }
        public IResult<InstaFeed> Feed { get; set; }
        public IResult<InstaStoryFeed> Stories { get; set; }
    }
}