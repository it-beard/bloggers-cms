using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Pds.Mappers;

namespace Pds.Api.AppStart
{
    public static class MappersExtensions
    {
        public static void AddAutoMapperCustom(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApiMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}