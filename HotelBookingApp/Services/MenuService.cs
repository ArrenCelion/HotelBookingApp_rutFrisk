﻿using HotelBookingApp.Services.ServiceInterfaces;
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
            string[] options = { "Rooms", "Guests", "Reservations", "Close Application" };
            DisplayMenu mainMenu = new DisplayMenu(prompt, options);

            return mainMenu;
        }

        public DisplayMenu CreateRoomMenu()
        {
            string prompt = "Room Menu:";
            string[] options = { "See all Rooms", "Add new Room", "Update Room", "Remove Room", "See all removed Rooms", "Delete Room", "Back to Main Menu" };
            DisplayMenu roomMenu = new DisplayMenu(prompt, options);

            return roomMenu;
        }

        public DisplayMenu CreateGuestMenu()
        {
            string prompt = "Guest Menu:";
            string[] options = { "See all Guests", "Search for Guest with Id", "New Guest", "Update Guest", "Remove Guest","See all removed Guests", "Delete Guest", "Back to Main Menu" };
            DisplayMenu guestMenu = new DisplayMenu(prompt, options);

            return guestMenu;
        }

        public DisplayMenu CreateReservationMenu()
        {
            string prompt = "Reservation Menu:";
            string[] options = { "See all Reservations", "New Reservation", "Update Reservation", "Remove Reservation", "See all removed Reservations", "Delete Reservation", "Back to Main Menu" };
            DisplayMenu guestMenu = new DisplayMenu(prompt, options);

            return guestMenu;
        }
    }
}
