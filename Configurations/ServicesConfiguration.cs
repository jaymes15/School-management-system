using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBWORK.DATA.DataContext;

namespace WEBWORK.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddDbConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("WEBWORK")));


           // services.AddMvc().AddJsonOptions(options =>
          //  {
          //      options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
//
           // });

            return services;
        }
    }
}
