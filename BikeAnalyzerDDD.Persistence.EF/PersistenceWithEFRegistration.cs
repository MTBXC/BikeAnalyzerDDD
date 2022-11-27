using BikeAnalyzerDDD.Application.Contracts.Persistence;
using BikeAnalyzerDDD.Persistence.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeAnalyzerDDD.Persistence.EF
{
    public static class PersistenceWithEFRegistration
    {
        public static IServiceCollection AddBikeAnalyzerDDDPersistenceEFServices(this IServiceCollection services)
        {
            services.AddDbContext<BikeAnalyzerDDDContext>();

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IBikeRepository, BikeRepository>();

            return services;
        }
    }
}