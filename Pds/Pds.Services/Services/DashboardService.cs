using Pds.Core.Enums;
using Pds.Data;
using Pds.Services.Interfaces;
using Pds.Services.Models.Dashboard;

namespace Pds.Services.Services;

public class DashboardService : IDashboardService
{
    private readonly IUnitOfWork unitOfWork;

    public DashboardService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<List<CountryStatisticsBrandModel>> GetCountriesStatisticsAsync()
    {
        return await unitOfWork.Dashboard.GetCountriesStatisticsAsync();
    }
    
    public async Task<List<MoneyStatisticsBrandModel>> GetMoneyStatisticsAsync()
    {
        return await unitOfWork.Dashboard.GetMoneyStatisticsAsync();
    }

    public async Task<List<ContentStatisticsBrandModel>> GetContentStatisticsAsync()
    {
        return await unitOfWork.Dashboard.GetContentStatisticsAsync();
    }
    
    public async Task<DateTime?> GetNearestNewEpisodeDateForDefaultBrandAsync()
    {
        var defaultBrand = await unitOfWork.Brands
            .GetFirstWhereAsync(b => b.IsDefault);
        var futureYoutubeContents = await unitOfWork.Content
            .FindAllByWhereAsync(c => 
                c.BrandId == defaultBrand.Id &&
                c.ReleaseDate >= DateTime.UtcNow &&
                c.SocialMediaType == SocialMediaType.YouTube &&
                c.Status != ContentStatus.Archived);
        
        // if there no contents - nearest palace in one week
        if (futureYoutubeContents.Count == 0)
        {
            return DateTime.UtcNow.AddDays(7);
        }

        var youtubeContents = futureYoutubeContents.ToArray();
        
        if ((youtubeContents[0].ReleaseDate - DateTime.UtcNow).TotalDays >= 14)
        {
            return DateTime.UtcNow.AddDays(7);
        }
        
        for (var i = 0; i < youtubeContents.Length; i++)
        {
            if (i+1 > youtubeContents.Length-1)
            {
                return youtubeContents[i].ReleaseDate.AddDays(7);
            }

            if ((youtubeContents[i+1].ReleaseDate - youtubeContents[i].ReleaseDate).TotalDays >= 14)
            {
                return youtubeContents[i].ReleaseDate.AddDays(7);
            }
        }
        
        return null;
    }
    
    public async Task<NearestIntegrationDateModel> GetNearestIntegrationDateForDefaultBrandAsync()
    {
        var defaultBrand = await unitOfWork.Brands
            .GetFirstWhereAsync(b => b.IsDefault);
        var nearestExistedEpisodeForIntegration = 
            await unitOfWork.Content.GetFirstWhereAsync(c => 
                c.BrandId == defaultBrand.Id &&
                c.ReleaseDate >= DateTime.UtcNow &&
                c.SocialMediaType == SocialMediaType.YouTube &&
                c.Type == ContentType.Integration &&
                c.Bill == null &&
                c.Status != ContentStatus.Archived);

        if (nearestExistedEpisodeForIntegration != null ||
            (nearestExistedEpisodeForIntegration.ReleaseDate- DateTime.UtcNow.Date).TotalDays >= 14)
        {
            return new NearestIntegrationDateModel()
            {
                BrandName = defaultBrand.Name,
                Date = nearestExistedEpisodeForIntegration.ReleaseDate,
                ContentId = nearestExistedEpisodeForIntegration.Id,
                ContentTitle = nearestExistedEpisodeForIntegration.Title
            };
        }
        
        var nearestNewEpisodeDate = await GetNearestNewEpisodeDateForDefaultBrandAsync();
        if (nearestNewEpisodeDate != null)
        {
            return new NearestIntegrationDateModel
            {
                BrandName = defaultBrand.Name,
                Date = nearestNewEpisodeDate
            };
        }

        return null;
    }
}