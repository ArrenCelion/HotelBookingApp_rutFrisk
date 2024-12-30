using HotelBookingApp.Controllers.ControllerInterfaces;
using HotelBookingApp.Services;
using HotelBookingApp.Services.ServiceInterfaces;
using HotelBookingApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.Controllers
{
    public class MenuController : IMenuController
    {
        IMenuService _menuService;
        IGuestController _guestController;
        public MenuController(IMenuService menuService, IGuestController guestController)
        {
            _menuService = menuService;
            _guestController = guestController; 
        }
        public void RunMainMenu()
        {

            var mainMenu = _menuService.CreateMainMenu();
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    RunRoomMenu();
                    break;
                case 1:
                    RunGuestMenu();
                    break;
                case 2:
                    RunBookingMenu();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }

        }

        public void RunRoomMenu()
        {
            var roomMenu = _menuService.CreateRoomMenu();
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
                    _roomController.UpdateRoom();
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("Removing room");
                    Console.ReadKey();
                    break;
                case 4:
                    RunMainMenu();
                    break;
            }
        }

        public void RunGuestMenu()
        {
            var guestMenu = _menuService.CreateGuestMenu();
            int selectedIndex = guestMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("List of all guests");
                    Console.ReadKey();
                    break;
                case 1:
                    Console.WriteLine("Adding new guest");
                    _guestController.AddGuest();
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
                    RunMainMenu();
                    break;
            }
        }

        public void RunBookingMenu()
        {
            var bookingMenu = _menuService.CreateBookingMenu();
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
                    RunMainMenu();
                    break;
            }
        }
    }
}
