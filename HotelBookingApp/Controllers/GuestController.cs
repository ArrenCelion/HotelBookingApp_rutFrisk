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
        public void AddGuest()
        {
            //Fix validation in utilities later
            string firstName = AnsiConsole.Ask<string>("First Name:");
            string lastName = AnsiConsole.Ask<string>("Last Name:");
            string email = AnsiConsole.Ask<string>("Email:");
            string phoneNumber = AnsiConsole.Ask<string>("Phonenumber:");
            DateTime dateOfBirth = AnsiConsole.Ask<DateTime>("Date of Birth (dd/MM/yyyy):"); //FIx year validation important!!!
            string address = AnsiConsole.Ask<string>("Address:");
            string postalCode = AnsiConsole.Ask<string>("Postal Code:");
            string city = AnsiConsole.Ask<string>("City:");
            bool isActive = true;


            Console.Clear();
            AnsiConsole.MarkupLine("\n[bold green]Sammanfattning av kundinformation:[/]");
            var table = new Table();
            table.AddColumn("[red]Information[/]");
            table.AddColumn("[red]Input[/]");
            table.AddRow("Name", firstName + " " + lastName);
            table.AddRow("Email", email);
            table.AddRow("Phone number", phoneNumber);
            table.AddRow("Date of Birth", dateOfBirth.ToShortDateString());
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
                guest.IsActive = isActive;
                _guestService.CreateNewGuest(guest);
            }
            else
            {
                // Meddelande om avbryta
                AnsiConsole.MarkupLine("[bold red]Registration terminated.[/]");
                Console.ReadKey();
                //_menuController.RunGuestMenu();
            }
        }
        public Guest GetGuestOptionInput(List<Guest> guests)
        {
            var guestArrayForDisplay = guests.Select(g => g.FirstName +" "+ g.LastName).ToArray();
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose Guest")
                .AddChoices(guestArrayForDisplay));

            var id = guests.Single(x => x.FirstName +" "+ x.LastName == option).GuestId;
            var guest = _guestService.GetGuestFromID(id);

            return guest;
        }

        public void GetActiveGuests()
        {
            var activeGuests = _guestService.ReadActiveGuests();
            DisplayEntities.ShowGuestTable(activeGuests);
        }

        public void GetInactiveGuests()
        {
            var inactiveGuests = _guestService.ReadInActiveGuests();
            DisplayEntities.ShowGuestTable(inactiveGuests);
        }
        public void SearchGuest()
        {
            int guestId = AnsiConsole.Ask<int>("Enter Guest ID:");
            var guest = _guestService.GetGuestFromID(guestId);
            if (guest == null)
            {
                Console.WriteLine("Guest not found.");
                return;
            }
            DisplayEntities.ShowGuestTable(new List<Guest> { guest });
        }
        public void UpdateGuest()
        {
            var allGuests = _guestService.ReadAllGuests();
            var guest = GetGuestOptionInput(allGuests);

            if (AnsiConsole.Confirm("Update First Name?"))
            {
                guest.FirstName = AnsiConsole.Ask<string>("Enter new First Name:");
            }
            if (AnsiConsole.Confirm("Update Last Name?"))
            {
                guest.LastName = AnsiConsole.Ask<string>("Enter new Last Name:");
            }
            if(AnsiConsole.Confirm("Update Email?"))
            {
                guest.Email = AnsiConsole.Ask<string>("Enter new Email:");
            }
            if (AnsiConsole.Confirm("Update Phone Number?"))
            {
                guest.PhoneNumber = AnsiConsole.Ask<string>("Enter new Phone Number:");
            }
            if (AnsiConsole.Confirm("Update Date of Birth?"))
            {
                guest.DateOfBirth = AnsiConsole.Ask<DateTime>("Enter new Date of Birth:");
            }
            if (AnsiConsole.Confirm("Update Address?"))
            {
                guest.Address = AnsiConsole.Ask<string>("Enter new Address:");
            }
            if (AnsiConsole.Confirm("Update Postal Code?"))
            {
                guest.PostalCode = AnsiConsole.Ask<string>("Enter new Postal Code:");
            }
            if (AnsiConsole.Confirm("Update City?"))
            {
                guest.City = AnsiConsole.Ask<string>("Enter new City:");
            }
            if (AnsiConsole.Confirm("Update Active status?"))
            {
                guest.IsActive = AnsiConsole.Confirm("Is the guest active?");
            }
            _guestService.UpdateGuest(guest);
        }

        public void RemoveGuest()
        {
            var activeGuests = _guestService.ReadActiveGuests();
            var guest = GetGuestOptionInput(activeGuests);
            if (AnsiConsole.Confirm("Are you sure you want to remove this guest? This will inactivate the guest so they can no longer make reservations"))
            {
                guest.IsActive = false;
            }
            _guestService.RemoveGuest(guest);
        }
        
        public void DeleteGuest()
        {
            var inactiveGuests = _guestService.ReadInActiveGuests();
            var guest = GetGuestOptionInput(inactiveGuests);
            if (AnsiConsole.Confirm("Are you sure you want to delete this guest? This will permanently delete the guest from the database and it will not be recoverable."))
            {
                _guestService.HardDeleteGuest(guest);
            }

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
