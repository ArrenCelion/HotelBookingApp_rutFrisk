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
using Bogus.DataSets;
using System.Numerics;

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

            string firstName = AnsiConsole.Ask<string>("First Name:");
            string lastName = AnsiConsole.Ask<string>("Last Name:");
            string email = AnsiConsole.Ask<string>("Email:");
            string phoneNumber = AnsiConsole.Ask<string>("Phonenumber:");
            DateTime dateOfBirth = AnsiConsole.Ask<DateTime>("Date of Birth:");
            string address = AnsiConsole.Ask<string>("Address:");
            string postalCode = AnsiConsole.Ask<string>("Postal Code:");
            string city = AnsiConsole.Ask<string>("City:");


            Console.Clear();
            AnsiConsole.MarkupLine("\n[bold green]Sammanfattning av kundinformation:[/]");
            var table = new Table();
            table.AddColumn("[red]Information[/]");
            table.AddColumn("[red]Input[/]");
            table.AddRow("Name", firstName + " " + lastName);
            table.AddRow("Email", email);
            table.AddRow("Phone number", phoneNumber);
            table.AddRow("Date of Birth", dateOfBirth.ToString());
            table.AddRow("Address", address);
            table.AddRow("Zip Code", postalCode);
            table.AddRow("City", city);
            AnsiConsole.Write(table);

            // Bekräfta kunduppgifter
            bool confirm = AnsiConsole.Confirm("\nIs this information correct?");

            if (confirm)
            {
                // Meddelande om lyckad registrering
                AnsiConsole.MarkupLine("[bold green]Guest registered successfully![/]");
                var guest = new Guest();
                guest.FirstName = firstName;
                guest.LastName = lastName;
                guest.Email = email;
                guest.PhoneNumber = phoneNumber;
                guest.DateOfBirth = dateOfBirth;
                guest.Address = address;
                guest.PostalCode = postalCode;
                guest.City = city;
                _guestService.CreateNewGuest(guest);
                Console.ReadKey();
                Console.WriteLine("Press any key to return to previous menu");
                // RedirectingService to call the menucontroller from further down the stack? _menuController.RunGuestMenu();
            }
            else
            {
                // Meddelande om avbryta
                AnsiConsole.MarkupLine("[bold red]Registration terminated.[/]");
                Console.ReadKey();
                //_menuController.RunGuestMenu();
            }


            //fix the rest of the needed information, move out address to it's own table? how to connect them?

            
            //CreateGuestInputValidation(guest); //när ska valideringen ske, hur kopplar man ihop det bra?
        }

        public void GetGuests()
        {
            Console.Clear();
            var allGuests = _guestService.ReadAllGuests();
            DisplayEntities.ShowGuestTable(allGuests);
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
