using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingApp.Utilities;
using HotelBookingApp.Services;
using HotelBookingApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using HotelBookingApp.Services.ServiceInterfaces;
using HotelBookingApp.Controllers.ControllerInterfaces;

namespace HotelBookingApp
{
    public class Application : IApplication
    {
        IMenuController _menuController;
        public Application(IMenuController menuController)
        {
            _menuController = menuController;
        }
        public void Run()
        {
            //TODO: 
            /* Implementera dbcontext med autofac https://chsamii.medium.com/register-ef-core-with-autofac-2c8cb76d52d6 */
            //Var ska koden in och hur förändrar det den kod jag redan har???
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);

            using (var dbContext = new ApplicationDbContext(options.Options))
            {
                dbContext.Database.Migrate();
            }

            StartMenu();
        }

        public void StartMenu()
        {
            _menuController.RunMainMenu();
        }
    }
}
