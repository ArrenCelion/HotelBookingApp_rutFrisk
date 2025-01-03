using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingApp.Controllers.ControllerInterfaces;
using HotelBookingApp.Models;
using HotelBookingApp.Services.ServiceInterfaces;
using HotelBookingApp.Utilities;
using Microsoft.Identity.Client;
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
            Console.Clear();
            AnsiConsole.MarkupLine("[bold]Add Reservation[/]");
            var arrivalDate = _calendarController.GetCalendarInput();
            var lengthOfStay = AnsiConsole.Ask<int>("Enter the length of stay in nights:");
            var departureDate = arrivalDate.AddDays(lengthOfStay);
            Console.Clear();
            var roomChoice = _reservationService.GetRoomChoice(arrivalDate, lengthOfStay);
            if (roomChoice == null)
                return;
            bool wantsExtraBed = ExtraBed(roomChoice);
            Console.Clear();
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
                reservation.WantsExtraBed = wantsExtraBed;
                _reservationService.CreateNewReservation(reservation);
                Console.WriteLine("Reservation created successfully");
            }
            else
            {
                AnsiConsole.MarkupLine("[bold red]Reservation cancelled.[/]");
            }
        }

        public void UpdateReservation()
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[bold]Update Reservation[/]");
            var allReservations = _reservationService.ReadAllReservations();
            var reservation = GetReservationOptionInput(allReservations);

            if (AnsiConsole.Confirm("Update ArrivalDate"))
            {
                while (true)
                {
                    reservation.ArrivalDate = _calendarController.GetCalendarInput();
                     
                    //Fix DRY??
                    var availableRooms = _reservationService.GetAvailableRooms(reservation.ArrivalDate, reservation.LengthOfStay);
                    bool isRoomAvailable = availableRooms.Any(r => r.RoomId == reservation.Room.RoomId);
                    if (!isRoomAvailable)
                    {
                        Console.WriteLine("Your current room is not available for the selected dates, please select a new room or change the dates");
                        if (!AnsiConsole.Confirm("Update room"))
                        {
                            continue;
                        }
                        else
                        {
                            var roomChoice = _reservationService.GetRoomChoice(reservation.ArrivalDate, reservation.LengthOfStay);
                            reservation.Room = roomChoice;
                            break;
                        }
                    }
                    else break;
                } //End of while loop
            }
            if (AnsiConsole.Confirm("Update Length of Stay"))
            {
                while (true)
                {
                    int newLengthOfStay = AnsiConsole.Ask<int>("Enter the length of stay in nights");
                    var availableRooms = _reservationService.GetAvailableRooms(reservation.ArrivalDate, newLengthOfStay);
                    reservation.LengthOfStay = newLengthOfStay;

                    bool isRoomAvailable = availableRooms.Any(r => r.RoomId == reservation.Room.RoomId);
                    if (!isRoomAvailable)
                    {
                        Console.WriteLine("Your current room is not available for the selected length of stay, please select a new room or change the length of stay.");
                        if (!AnsiConsole.Confirm("Update room"))
                        {
                            
                            continue;
                        }
                        else
                        {
                            var roomChoice = _reservationService.GetRoomChoice(reservation.ArrivalDate, newLengthOfStay);
                            reservation.Room = roomChoice;
                            break;
                        }
                    }
                    else break;
                } //End of while loop
            }

            if (AnsiConsole.Confirm("Update room"))
            {
                var roomChoice = _reservationService.GetRoomChoice(reservation.ArrivalDate, reservation.LengthOfStay);
                reservation.Room = roomChoice;
            }
            if (AnsiConsole.Confirm("Update Guest"))
            {
                var activeGuests = _guestService.ReadActiveGuests();
                var guest = _guestController.GetGuestOptionInput(activeGuests);
                reservation.Guest = guest;
            }
            if(reservation.Room.IsSingle && reservation.Room.RoomSize < 15)
            {
                if (AnsiConsole.Confirm("Update choice about extra bed?"))
                {
                    reservation.WantsExtraBed = false;
                }
            }
            else
                reservation.WantsExtraBed = ExtraBed(reservation.Room);

            if (AnsiConsole.Confirm("Update Active Status?"))
            {
                reservation.IsActive = AnsiConsole.Confirm("Is the reservation Active?");
            }
            _reservationService.UpdateReservation(reservation);
        }
    

        public Reservation GetReservationOptionInput(List<Reservation> reservations)
        {
            var reservationArrayToDisplay = reservations.Select(r => r.ReservationId.ToString() + " " + r.Guest.FirstName + " " + r.Guest.LastName).ToArray();
            if (reservationArrayToDisplay.Length != 0)
            {
                var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                            .Title("Select a reservation")
                            .AddChoices(reservationArrayToDisplay));

                var id = reservations.Single(r => r.ReservationId.ToString() + " " + r.Guest.FirstName + " " + r.Guest.LastName == option).ReservationId;
                var reservation = _reservationService.GetReservationFromID(id);

                return reservation;
            }
            else Console.WriteLine("No Reservation found");
            return null;

        }
        public bool ExtraBed(Room roomChoice)
        {
            bool wantsExtraBed = false;
            if (!roomChoice.IsSingle && roomChoice.RoomSize >= 15)
            {
                if (AnsiConsole.Confirm("Would you like to add an extra bed to the room?"))
                {
                    wantsExtraBed = true;
                }
            }
            return wantsExtraBed;
        }

        public void GetActiveReservations()
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[bold]Active Reservations[/]");
            var activeReservations = _reservationService.ReadActiveReservations();
            DisplayEntities.ShowReservationTable(activeReservations);
        }

        public void GetInactiveReservations()
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[bold]Inactive Reservations[/]");
            var inactiveReservations = _reservationService.ReadInactiveReservations();
            DisplayEntities.ShowReservationTable(inactiveReservations);
        }

        public void RemoveReservation()
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[bold]Remove Reservation[/]");
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
            Console.Clear();
            AnsiConsole.MarkupLine("[bold]Delete Reservation[/]");
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
