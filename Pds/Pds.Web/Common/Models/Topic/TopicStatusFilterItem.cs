using Pds.Core.Enums;

namespace Pds.Web.Common.Models.Topic
{
    public class TopicStatusFilterItem
    {
        public TopicStatusFilterItem(TopicStatus status, bool isSelected)
        {
            Status = status;
            IsSelected = isSelected;
        }

        public TopicStatus Status { get; set; }

        public bool IsSelected { get; set; }
    }
}