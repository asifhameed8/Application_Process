using Hahn.ApplicatonProcess.December2020.Domain.Services.ApplicationSrv;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Domain.Services
{
    public static class ServicesModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IApplication, ApplicationService>();
        }
    }
}
