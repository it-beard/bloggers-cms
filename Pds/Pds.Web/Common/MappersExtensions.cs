﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Pds.Mappers;

namespace Pds.Web.Common
{
    public static class MappersExtensions
    {
        public static void AddCustomAutoMapper(this IServiceCollection services)
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