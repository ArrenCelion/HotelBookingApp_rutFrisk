using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingApp.Utilities;
using HotelBookingApp.Controllers.ControllerInterfaces;

namespace HotelBookingApp.Controllers
{
    internal class CalendarController : ICalendarController
    {
        public DateTime GetCalendarInput()
        {
            // Startdatum (början av månaden)
            DateTime currentDate = DateTime.Now;
            DateTime selectedDate = new DateTime(currentDate.Year, currentDate.Month, 1);

            while (true)
            {
                Console.Clear();
                DisplayCalendar.RenderCalendar(selectedDate);

                // Läsa användarens tangent
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.RightArrow:
                        selectedDate = selectedDate.AddDays(1);
                        break;
                    case ConsoleKey.LeftArrow:
                        selectedDate = selectedDate.AddDays(-1);
                        break;
                    case ConsoleKey.UpArrow:
                        selectedDate = selectedDate.AddDays(-7);
                        break;
                    case ConsoleKey.DownArrow:
                        selectedDate = selectedDate.AddDays(7);
                        break;
                    case ConsoleKey.Enter:
                        if(selectedDate < DateTime.Now.Date)
                        {
                            AnsiConsole.MarkupLine("[red]You can't choose an arrivaldate that has already passed![/]\nPress any key to pick a new date");
                            Console.ReadKey();
                            continue;
                        }
                        if (AnsiConsole.Confirm($"Your selected arrival date is: {selectedDate:yyyy-MM-dd}? "))
                        {
                            return selectedDate;
                        }
                        else continue;
                    case ConsoleKey.Escape: // Avbryter valet
                        // go back to previous menu
                        break; // Avbryter valet
                }
            }
        }
    }
}
