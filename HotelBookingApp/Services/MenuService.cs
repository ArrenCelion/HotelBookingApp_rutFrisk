using HotelBookingApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.Services
{
    internal class MenuService
    {



        //Går det att göra detta mindre?? DRY? + if already created do not create again
        public DisplayMenu CreateMainMenu()
        {
            string prompt = "Welcome to the Hotell, what do you wanna check?";
            string[] options = { "Rooms", "Guests", "Bookings", "Close App" };
            DisplayMenu mainMenu = new DisplayMenu(prompt, options);

            return mainMenu;
        }

        public DisplayMenu CreateRoomMenu()
        {
            string prompt = "Room Menu:";
            string[] options = { "See all Rooms","Add new Room", "Update Room", "Remove Room", "Back to Main Menu" };
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
            string prompt = "Booking Menu:";
            string[] options = { "See all Bookings", "New Booking", "Update Booking", "Remove Booking", "Back to Main Menu" };
            DisplayMenu guestMenu = new DisplayMenu(prompt, options);

            return guestMenu;
        }
    }
}
