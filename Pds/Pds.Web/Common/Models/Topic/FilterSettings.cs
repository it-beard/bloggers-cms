using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Pds.Core.Enums;

namespace Pds.Web.Common.Models.Topic
{
    public class FilterSettings : IValidatableObject
    {
        public FilterSettings()
        {
            TopicStatusFilter = new TopicStatusFilterItem[]
            {
                new(TopicStatus.Archived, false),
                new(TopicStatus.Active, true)
            };
        }

        [Range(0d, 100d)] public double? MinRateAverage { get; set; }

        [Range(0d, 100d)] public double? MaxRateAverage { get; set; }

        [Range(0, int.MaxValue)] public int? MinPeopleCount { get; set; }

        [Range(0, int.MaxValue)] public int? MaxPeopleCount { get; set; }

        public string NameFilter { get; set; }

        public IReadOnlyCollection<TopicStatusFilterItem> TopicStatusFilter { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (MinRateAverage > MaxRateAverage)
                yield return new ValidationResult("Invalid Rate Average filter value",
                    Enumerable.Repeat(nameof(MinRateAverage),
                        1));

            if (MinPeopleCount > MaxPeopleCount)
                yield return new ValidationResult("Invalid People Count filter value",
                    Enumerable.Repeat(nameof(MinPeopleCount),
                        1));
        }
    }
}