﻿using System;
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
        public ReservationController(IReservationService reservationService, ICalendarController calendarController)
        {
            _reservationService = reservationService;
            _calendarController = calendarController;
        }
        public void AddReservation()
        {
            var arrivalDate = _calendarController.GetCalendarInput();
            Console.WriteLine(arrivalDate.ToShortDateString());
            //How to connect the reservation to guest and room?
            //using spectre calendar to select 
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
