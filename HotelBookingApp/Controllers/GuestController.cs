using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingApp.Utilities.Validation;
using FluentValidation.Results;

namespace HotelBookingApp.Controllers
{
    internal class GuestController
    {
        //Ask the Service for Crud and send back information


        //Middle man for inputs and requests? Service <-> Controller <-> Utilities ??
        public void CreateGuestInputValidation(Guest newGuest)
        {

            // Skapa validatorn
            var validator = new GuestValidator();

            // Validera kunden
            ValidationResult modelState = validator.Validate(newGuest);

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
