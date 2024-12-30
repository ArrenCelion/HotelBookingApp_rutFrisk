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
        ApplicationDbContext _dbContext;
        IDataInitializer _dataInitializer;
        public Application(IMenuController menuController, ApplicationDbContext dbContext, IDataInitializer dataInitializer)
        {
            _menuController = menuController;
            _dbContext = dbContext;
            _dataInitializer = dataInitializer;
        }
        public void Run()
        {
            _dataInitializer.MigrateAndSeed();
            StartMenu();
        }

        public void StartMenu()
        {
            _menuController.RunMainMenu();
        }
    }
}
