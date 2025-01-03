using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingApp.Controllers.ControllerInterfaces;
using HotelBookingApp.Models;
using HotelBookingApp.Services.ServiceInterfaces;
using HotelBookingApp.Utilities;
using Spectre.Console;

namespace HotelBookingApp.Controllers
{
    public class ReservationController : IReservationController
    {
        IReservationService _reservationService;
        ICalendarController _calendarController;
        IRoomController _roomController;
        IGuestController _guestController;
        IGuestService _guestService;
        public ReservationController(IReservationService reservationService, ICalendarController calendarController,
               IRoomController roomController, IGuestController guestController, IGuestService guestService)
        {
            _reservationService = reservationService;
            _calendarController = calendarController;
            _roomController = roomController;
            _guestController = guestController;
            _guestService = guestService;
        }
        public void AddReservation()
        {
            var arrivalDate = _calendarController.GetCalendarInput();
            var lengthOfStay = AnsiConsole.Ask<int>("Enter the length of stay in nights");
            var departureDate = arrivalDate.AddDays(lengthOfStay);
            var activeReservations = _reservationService.ReadActiveReservations();
            List<Room> availableRooms = _reservationService.GetAvailableRooms(arrivalDate, departureDate, activeReservations);
            if(availableRooms == null)
            {
                Console.WriteLine("No rooms available for the selected dates");
                return;

            }
            //extract method
            var roomChoice = _roomController.GetRoomOptionInput(availableRooms);
            bool wantsExtraBed = false;
            if (!roomChoice.IsSingle && roomChoice.RoomSize >= 15)
            {
                if(AnsiConsole.Confirm("Would you like to add an extra bed to the room?"))
                {
                     wantsExtraBed = true;
                }              
            }
            
            if (!AnsiConsole.Confirm("Are you registered as a guest?"))
            {
                _guestController.AddGuest();
            }
            var activeGuests = _guestService.ReadActiveGuests();
            var guest = _guestController.GetGuestOptionInput(activeGuests);

            Console.Clear();
            AnsiConsole.MarkupLine($"[bold]Reservation for {guest.FirstName} {guest.LastName}[/]");
            var table = new Table();
            table.AddColumn("Information");
            table.AddColumn("Input");
            table.AddRow("Arrival Date", arrivalDate.ToShortDateString());
            table.AddRow("Departure Date", departureDate.ToShortDateString());
            table.AddRow("Length of Stay", lengthOfStay.ToString());
            table.AddRow("Room Number", roomChoice.RoomNumber.ToString());
            table.AddRow("Room type", roomChoice.IsSingle ? "Single" : "Double");
            table.AddRow("Extra Bed", wantsExtraBed ? "Yes" : "No");
            AnsiConsole.Write(table);

            bool confirm = AnsiConsole.Confirm("Is this information correct?");
            if (confirm)
            {
                var reservation = new Reservation();
                reservation.ArrivalDate = arrivalDate;
                reservation.LengthOfStay = lengthOfStay;
                reservation.Room = roomChoice;
                reservation.Guest = guest;
                reservation.IsActive = true;
                _reservationService.CreateNewReservation(reservation);
                Console.WriteLine("Reservation created successfully");
            }
            else
            {
                AnsiConsole.MarkupLine("[bold red]Reservation cancelled.[/]");
            }
        }
    

        public Reservation GetReservationOptionInput(List<Reservation> reservations)
        {
            var reservationArrayToDisplay = reservations.Select(r => r.ReservationId.ToString()).ToArray();
            if (reservationArrayToDisplay.Length != 0)
            {
                var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                            .Title("Select a reservation")
                            .AddChoices(reservationArrayToDisplay));

                var id = reservations.Single(r => r.ReservationId.ToString() == option).ReservationId;
                var reservation = _reservationService.GetReservationFromID(id);

                return reservation;
            }
            else Console.WriteLine("No Reservation found");
            return null;

        }
        public void GetActiveReservations()
        {
            var activeReservations = _reservationService.ReadActiveReservations();
            DisplayEntities.ShowReservationTable(activeReservations);
        }

        public void GetInactiveReservations()
        {
            var inactiveReservations = _reservationService.ReadInactiveReservations();
            DisplayEntities.ShowReservationTable(inactiveReservations);
        }

        public void RemoveReservation()
        {
            var activeReservations = _reservationService.ReadActiveReservations();
            var reservation = GetReservationOptionInput(activeReservations);

            if (reservation == null)
                return;

            if (AnsiConsole.Confirm("Are you sure you want to remove this reservation?"))
            {
                reservation.IsActive = false;
            }
            _reservationService.RemoveReservation(reservation);
        }

        public void DeleteReservation()
        {
            var inactiveReservations = _reservationService.ReadInactiveReservations();
            var reservation = GetReservationOptionInput(inactiveReservations);
            if (reservation == null)
                return;
            if (AnsiConsole.Confirm("Are you sure you want to delete this reservation? This will permanently delete the reservation from the database and it will not be recoverable."))
            {
                _reservationService.HardDeleteReservation(reservation);
            }
        }
    }
}
