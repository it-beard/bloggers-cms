using Pds.Api.Contracts.Content;
using Pds.Core.Enums;

namespace Pds.Web.Pages.Content
{
    public static class TopicsHelper
    {
        public static string GetBgColorClass(TopicStatus topicStatus)
        {
            return topicStatus switch
            {
                TopicStatus.Active => "active",
                TopicStatus.Archived => "archived",
                _ => string.Empty
            };
        }
    }
}