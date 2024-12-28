using HotelBookingApp.Services;
using HotelBookingApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.Controllers
{
    internal class MenuController
    {

        public void RunMainMenu(MenuService menuService) 
        {
            
            var mainMenu = menuService.CreateMainMenu();
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    RunRoomMenu(menuService);
                    break;
                case 1:
                    RunGuestMenu(menuService);
                    break;
                case 2:
                    RunBookingMenu(menuService);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }

        }

        public void RunRoomMenu(MenuService menuService)
        {
            var roomMenu = menuService.CreateRoomMenu();
            int selectedIndex = roomMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("List of all rooms");
                    Console.ReadKey();
                    break;
                case 1:
                    Console.WriteLine("Adding new room");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("Updating room");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("Removing room");
                    Console.ReadKey();
                    break;
                case 4:
                    RunMainMenu(menuService);
                    break;
            }
        }

        public void RunGuestMenu(MenuService menuService)
        {
            var guestMenu = menuService.CreateGuestMenu();
            int selectedIndex = guestMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("List of all guests");
                    Console.ReadKey();
                    break;
                case 1:
                    Console.WriteLine("Adding new guest");
                    GuestController.AddGuest();
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("Updating guest");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("Removing guest");
                    Console.ReadKey();
                    break;
                case 4:
                    RunMainMenu(menuService);
                    break;
            }
        }

        public void RunBookingMenu(MenuService menuService)
        {
            var bookingMenu = menuService.CreateBookingMenu();
            int selectedIndex = bookingMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("List of all bookings");
                    Console.ReadKey();
                    break;
                case 1:
                    Console.WriteLine("Adding new booking");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("Updating booking");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("Removing booking");
                    Console.ReadKey();
                    break;
                case 4:
                    RunMainMenu(menuService);
                    break;
            }
        }
    }
}
