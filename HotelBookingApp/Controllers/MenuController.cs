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
        IRoomController _roomController;
        public MenuController(IMenuService menuService, IGuestController guestController, IRoomController roomController)
        {
            _menuService = menuService;
            _guestController = guestController;
            _roomController = roomController;
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
                    _roomController.GetActiveRooms();
                    Console.ReadKey();
                    break;
                case 1:
                    Console.WriteLine("Add new room");
                    _roomController.AddRoom();
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("Update room");
                    _roomController.UpdateRoom();
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("Remove room");
                    _roomController.RemoveRoom();
                    Console.ReadKey();
                    break;
                case 4:
                    Console.WriteLine("List of all inactive rooms");
                    _roomController.GetInactiveRooms();
                    Console.ReadKey();
                    break;
                case 5:
                    Console.WriteLine("Delete a room");
                    _roomController.DeleteRoom();
                    Console.ReadKey();
                    break;
                case 6:
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
                    _guestController.GetActiveGuests();
                    Console.ReadKey();
                    break;
                case 1:
                    Console.WriteLine("Adding new guest");
                    _guestController.AddGuest();
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("Updating guest");
                    _guestController.UpdateGuest();
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("Removing guest");
                    _guestController.RemoveGuest();
                    Console.ReadKey();
                    break;
                case 4:
                    Console.WriteLine("List of all inactive guests");
                    _guestController.GetInactiveGuests();
                    Console.ReadKey();
                    break;
                case 5:
                    Console.WriteLine("Delete a guest");
                    _guestController.DeleteGuest();
                    Console.ReadKey();
                    break;
                case 6:
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
