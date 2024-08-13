using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLight;

namespace TrafficLightSimulation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDI(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<SampleTrafficLight>();
            services.AddTransient<ICarHandler, CarHandler>();
            services.AddTransient<ITrafficLightHandler, TrafficLightHandler>();
            services.AddTransient<ITrafficLight, SampleTrafficLight>();
            return services;
        }
    }
}
