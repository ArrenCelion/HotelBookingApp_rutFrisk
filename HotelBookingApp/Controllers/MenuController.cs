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
                    RunReservationMenu();
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
                    
                    _roomController.GetActiveRooms();
                    ReturnToPreviousMenu();
                    RunRoomMenu();
                    break;
                case 1:
                    
                    _roomController.AddRoom();
                    ReturnToPreviousMenu();
                    RunRoomMenu();
                    break;
                case 2:
                    
                    _roomController.UpdateRoom();
                    ReturnToPreviousMenu();
                    RunRoomMenu();
                    break;
                case 3:
                    
                    _roomController.RemoveRoom();
                    ReturnToPreviousMenu();
                    RunRoomMenu();
                    break;
                case 4:
                    
                    _roomController.GetInactiveRooms();
                    ReturnToPreviousMenu();
                    RunRoomMenu();
                    break;
                case 5:
                    
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
                    
                    _guestController.GetActiveGuests();
                    ReturnToPreviousMenu();
                    RunGuestMenu();
                    break;
                case 1:
                    
                    _guestController.SearchGuest();
                    ReturnToPreviousMenu();
                    RunGuestMenu();
                    break;
                case 2:
                    
                    _guestController.AddGuest();
                    ReturnToPreviousMenu();
                    RunGuestMenu();
                    break;
                case 3:
                    
                    _guestController.UpdateGuest();
                    ReturnToPreviousMenu();
                    RunGuestMenu();
                    break;
                case 4:
                    
                    _guestController.RemoveGuest();
                    ReturnToPreviousMenu();
                    RunGuestMenu();
                    break;
                case 5:
                    
                    _guestController.GetInactiveGuests();
                    ReturnToPreviousMenu();
                    RunGuestMenu();
                    break;
                case 6:
                    
                    _guestController.DeleteGuest();
                    ReturnToPreviousMenu();
                    RunGuestMenu();
                    break;
                case 7:
                    RunMainMenu();
                    break;
            }
        }

        public void RunReservationMenu()
        {
            var reservationMenu = _menuService.CreateReservationMenu();
            int selectedIndex = reservationMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    
                    _reservationController.GetActiveReservations();
                    ReturnToPreviousMenu();
                    RunReservationMenu();
                    break;
                case 1:
                    
                    _reservationController.AddReservation();
                    ReturnToPreviousMenu();
                    RunReservationMenu();
                    break;
                case 2:
                   
                    _reservationController.UpdateReservation();
                    ReturnToPreviousMenu();
                    RunReservationMenu();
                    break;
                case 3:
                    
                    _reservationController.RemoveReservation();
                    ReturnToPreviousMenu();
                    RunReservationMenu();
                    break;
                case 4:
                    
                    _reservationController.GetInactiveReservations();
                    ReturnToPreviousMenu();
                    RunReservationMenu();
                    break;
                case 5:
                    
                    _reservationController.DeleteReservation();
                    ReturnToPreviousMenu();
                    RunReservationMenu();
                    break;
                case 6:
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
