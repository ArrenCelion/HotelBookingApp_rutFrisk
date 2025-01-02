using HotelBookingApp.Services.ServiceInterfaces;
using HotelBookingApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.Services
{
    public class MenuService : IMenuService
    {



        //Går det att göra detta mindre?? DRY? + if already created do not create again Autofac?? Spectre.Console??
        public DisplayMenu CreateMainMenu()
        {
            string prompt = "Welcome to the Hotell, what do you wanna check?";
            string[] options = { "Rooms", "Guests", "Bookings", "Close Application" };
            DisplayMenu mainMenu = new DisplayMenu(prompt, options);

            return mainMenu;
        }

        public DisplayMenu CreateRoomMenu()
        {
            string prompt = "Room Menu:";
            string[] options = { "See all Rooms", "Add new Room", "Update Room", "Remove Room", "See all removed rooms", "Delete Room", "Back to Main Menu" };
            DisplayMenu roomMenu = new DisplayMenu(prompt, options);

            return roomMenu;
        }

        public DisplayMenu CreateGuestMenu()
        {
            string prompt = "Guest Menu:";
            string[] options = { "See all Guests", "New Guest", "Update Guest", "Remove Guest", "Back to Main Menu" };
            DisplayMenu guestMenu = new DisplayMenu(prompt, options);

            return guestMenu;
        }

        public DisplayMenu CreateBookingMenu()
        {
            string prompt = "Reservation Menu:";
            string[] options = { "See all Bookings", "New Reservation", "Update Reservation", "Remove Reservation", "Back to Main Menu" };
            DisplayMenu guestMenu = new DisplayMenu(prompt, options);

            return guestMenu;
        }
    }
}
