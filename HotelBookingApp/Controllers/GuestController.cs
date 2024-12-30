using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingApp.Utilities.Validation;
using FluentValidation.Results;
using HotelBookingApp.Models;
using Spectre.Console;
using HotelBookingApp.Services;
using HotelBookingApp.Data;
using HotelBookingApp.Services.ServiceInterfaces;
using HotelBookingApp.Controllers.ControllerInterfaces;
using HotelBookingApp.Utilities;
using System.Runtime.CompilerServices;

namespace HotelBookingApp.Controllers
{
    public class GuestController : IGuestController
    {
        IGuestService _guestService;
        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }
        //Ask the Service for Crud and send back information
        public void AddGuest()
        {

            var guest = new Guest();
            guest.FirstName = AnsiConsole.Ask<string>("First Name:");
            guest.LastName = AnsiConsole.Ask<string>("Last Name:");
            guest.Email = AnsiConsole.Ask<string>("Email:");
            guest.PhoneNumber = AnsiConsole.Ask<string>("Phonenumber:");
            //fix the rest of the needed information, move out address to it's own table? how to connect them?
            
            _guestService.CreateNewGuest(guest);
            //CreateGuestInputValidation(guest); //när ska valideringen ske, hur kopplar man ihop det bra?
        }

        public void GetGuests()
        {
            var allGuests = _guestService.ReadAllGuests();
            DisplayItems.ShowGuestTable(allGuests);
        }


        //Middle man for inputs and requests? Service <-> Controller <-> Utilities ??
        public void CreateGuestInputValidation(Guest newGuest)
        {

            // Skapa validatorn
            var validator = new GuestValidator();

            // Validera kunden
            FluentValidation.Results.ValidationResult modelState = validator.Validate(newGuest);

            // Hantera valideringsresultat
            if (!modelState.IsValid)
            {
                foreach (var failure in modelState.Errors)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Property {failure.PropertyName} failed validation. Error: {failure.ErrorMessage}");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Customer is valid!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
