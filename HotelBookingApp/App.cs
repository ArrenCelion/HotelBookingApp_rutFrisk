using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingApp.Utilities;
using HotelBookingApp.Controllers;
using HotelBookingApp.Services;

namespace HotelBookingApp
{
    internal class App
    {
        public void Run()
        {
            StartMenu();
        }

        public void StartMenu()
        {
            MenuController menuController = new MenuController();
            MenuService menuService = new MenuService();
            menuController.RunMainMenu(menuService);
        }
    }
}
