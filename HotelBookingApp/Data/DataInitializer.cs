﻿using HotelBookingApp.Data;
using HotelBookingApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.Data
{
    internal class DataInitializer
    {
        public void MigrateAndSeed(ApplicationDbContext dbContext)
        {
            dbContext.Database.Migrate();
            //SeedGuests(dbContext);
            dbContext.SaveChanges();
        }

        private void SeedGuests()
        {
            //Använda bogus? 
        }


       /* private void SeedMenus(ApplicationDbContext dbContext)
        {
            if (!dbContext.Menu.Any(m => m.Name == "Main Menu"))
            {
                dbContext.Menu.Add(new Menu
                {
                    MenuName = "Main Menu",
                    MenuPrompt = "Welcome to the Hotell, what do you wanna check?",
                    //MenuOptions = { "Rooms", "Guests", "Bookings", "Close App" } //Göra till ett eget table i en class som heter MenuOptions som blir seedad? och lägga in MenuId som fk i den?
                });
            }

            if (!dbContext.Menu.Any(m => m.Name == "Room Menu"))
            {
                dbContext.Menu.Add(new Menu
                {
                    MenuName = "Room Menu",
                    MenuPrompt = "Room Menu:",
                    //MenuOptions = { "Rooms", "Guests", "Bookings", "Close App" } //Göra till ett eget table i en class som heter MenuOptions som blir seedad? och lägga in MenuId som fk i den?
                });
            }

            if (!dbContext.Menu.Any(m => m.Name == "Guest Menu"))
            {
                dbContext.Menu.Add(new Menu
                {
                    MenuName = "Guest Menu",
                    MenuPrompt = "Guest Menu:",
                    //MenuOptions = { "Rooms", "Guests", "Bookings", "Close App" } //Göra till ett eget table i en class som heter MenuOptions som blir seedad? och lägga in MenuId som fk i den?
                });
            }

            if (!dbContext.Menu.Any(m => m.Name == "Reservation Menu"))
            {
                dbContext.Menu.Add(new Menu
                {
                    MenuName = "Reservation Menu",
                    MenuPrompt = "Reservation Menu:",
                    //MenuOptions = { "Rooms", "Guests", "Bookings", "Close App" } //Göra till ett eget table i en class som heter MenuOptions som blir seedad? och lägga in MenuId som fk i den?
                });
            }

        }

        private void SeedMenuOptions(ApplicationDbContext dbContext)
        {
            if (!dbContext.MenuOption.Any(m => m.Name == "Main Menu"))
            {
                dbContext.MenuOption.Add(new MenuOption
                {
                    OptionName = "Main Menu",
                    MenuId = 0,
                });
            }
        }*/
    }
}
