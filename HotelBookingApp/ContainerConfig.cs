using Autofac;
using HotelBookingApp.Controllers;
using HotelBookingApp.Controllers.ControllerInterfaces;
using HotelBookingApp.Data;
using HotelBookingApp.Services;
using HotelBookingApp.Services.ServiceInterfaces;
using HotelBookingApp.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
            builder.RegisterType<DataInitializer>().As<IDataInitializer>();

            /* Menu */
            builder.RegisterType<MenuController>().As<IMenuController>();
            builder.RegisterType<MenuService>().As<IMenuService>();
            builder.RegisterType<DisplayMenu>().As<IDisplayMenu>();

            /* Guest */
            builder.RegisterType<GuestController>().As<IGuestController>();
            builder.RegisterType<GuestService>().As<IGuestService>();

            /* Room */
            builder.RegisterType<RoomController>().As<IRoomController>();
            builder.RegisterType<RoomService>().As<IRoomService>();

            /* Reservation */
            builder.RegisterType<ReservationController>().As<IReservationController>();
            builder.RegisterType<ReservationService>().As<IReservationService>();

            /* Implementera dbcontext med autofac https://chsamii.medium.com/register-ef-core-with-autofac-2c8cb76d52d6 */
            var dbBuilder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = dbBuilder.Build();

            builder.Register(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                var connectionString = config.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
                return new ApplicationDbContext(optionsBuilder.Options);
            }).InstancePerLifetimeScope();


            //builder.RegisterAssemblyTypes(Assembly.Load(nameof(HotelBookingApp)))
            //    .Where(t => t.Name.EndsWith("Service"))
            //    .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            //builder.RegisterAssemblyTypes(Assembly.Load(nameof(HotelBookingApp)))
            //    .Where(t => t.Name.EndsWith("Controller"))
            //    .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            //builder.RegisterAssemblyTypes(Assembly.Load(nameof(HotelBookingApp)))
            //    .Where(t => t.Name.EndsWith("Menu"))
            //    .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}

