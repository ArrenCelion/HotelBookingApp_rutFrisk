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
        IReservationController _reservationController;
        public MenuController(IMenuService menuService, IGuestController guestController, IRoomController roomController, IReservationController reservationController)
        {
            _menuService = menuService;
            _guestController = guestController;
            _roomController = roomController;
            _reservationController = reservationController;
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
                    ReturnToPreviousMenu();
                    RunRoomMenu();
                    break;
                case 1:
                    Console.WriteLine("Add new room");
                    _roomController.AddRoom();
                    ReturnToPreviousMenu();
                    RunRoomMenu();
                    break;
                case 2:
                    Console.WriteLine("Update room");
                    _roomController.UpdateRoom();
                    ReturnToPreviousMenu();
                    RunRoomMenu();
                    break;
                case 3:
                    Console.WriteLine("Remove room");
                    _roomController.RemoveRoom();
                    ReturnToPreviousMenu();
                    RunRoomMenu();
                    break;
                case 4:
                    Console.WriteLine("List of all inactive rooms");
                    _roomController.GetInactiveRooms();
                    ReturnToPreviousMenu();
                    RunRoomMenu();
                    break;
                case 5:
                    Console.WriteLine("Delete a room");
                    _roomController.DeleteRoom();
                    ReturnToPreviousMenu();
                    RunRoomMenu();
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
                    ReturnToPreviousMenu();
                    RunGuestMenu();
                    break;
                case 1:
                    Console.WriteLine("Search for a guest with Id");
                    _guestController.SearchGuest();
                    ReturnToPreviousMenu();
                    RunGuestMenu();
                    break;
                case 2:
                    Console.WriteLine("Adding new guest");
                    _guestController.AddGuest();
                    ReturnToPreviousMenu();
                    RunGuestMenu();
                    break;
                case 3:
                    Console.WriteLine("Updating guest");
                    _guestController.UpdateGuest();
                    ReturnToPreviousMenu();
                    RunGuestMenu();
                    break;
                case 4:
                    Console.WriteLine("Removing guest");
                    _guestController.RemoveGuest();
                    ReturnToPreviousMenu();
                    RunGuestMenu();
                    break;
                case 5:
                    Console.WriteLine("List of all inactive guests");
                    _guestController.GetInactiveGuests();
                    ReturnToPreviousMenu();
                    RunGuestMenu();
                    break;
                case 6:
                    Console.WriteLine("Delete a guest");
                    _guestController.DeleteGuest();
                    ReturnToPreviousMenu();
                    RunGuestMenu();
                    break;
                case 7:
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
                    Console.WriteLine("List of all Reservations");
                    _reservationController.GetActiveReservations();
                    ReturnToPreviousMenu();
                    RunBookingMenu();
                    break;
                case 1:
                    Console.WriteLine("Adding new Reservation");
                    _reservationController.AddReservation();
                    ReturnToPreviousMenu();
                    RunBookingMenu();
                    break;
                case 2:
                    Console.WriteLine("Updating booking");
                    ReturnToPreviousMenu();
                    RunBookingMenu();
                    break;
                case 3:
                    Console.WriteLine("Removing booking");
                    _reservationController.RemoveReservation();
                    ReturnToPreviousMenu();
                    RunBookingMenu();
                    break;
                case 4:
                    RunMainMenu();
                    break;
            }
        }

        public void ReturnToPreviousMenu()
        {
            Console.WriteLine("Press any key to go back to previous menu");
            Console.ReadKey();
        }
    }
}
