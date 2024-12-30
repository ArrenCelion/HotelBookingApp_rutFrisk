using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(HotelBookingApp)))
                .Where(t => t.Name.EndsWith("Service"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(HotelBookingApp)))
                .Where(t => t.Name.EndsWith("Controller"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(HotelBookingApp)))
                .Where(t => t.Name.EndsWith("Menu"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}
