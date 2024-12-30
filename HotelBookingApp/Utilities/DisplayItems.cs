using HotelBookingApp.Models;
using Spectre.Console;

namespace HotelBookingApp.Utilities
{
    internal class DisplayItems
    {
        static internal void ShowGuestTable(List<Guest> guests)
        {
            var table = new Table();
            table.AddColumn("First Name");
            table.AddColumn("Last Name");
            table.AddColumn("Email");
            table.AddColumn("Phone Number");

            foreach (Guest guest in guests)
            {
                table.AddRow(
                    guest.FirstName,
                    guest.LastName,
                    guest.Email,
                    guest.PhoneNumber
                    );
            }

            AnsiConsole.Write(table);

            Console.WriteLine("Press any key to go back");
            Console.ReadLine();
            Console.Clear();
        }
    }
}