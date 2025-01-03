﻿using HotelBookingApp.Models;

namespace HotelBookingApp.Services.ServiceInterfaces
{
    public interface IReservationService
    {
        void CreateNewReservation(Reservation reservation);
        void HardDeleteReservation(Reservation reservation);
        List<Reservation> ReadActiveReservations();
        List<Reservation> ReadInactiveReservations();
        Reservation GetReservationFromID(int reservationId);
        void RemoveReservation(Reservation reservation);
        void UpdateReservation();
        List<Room> GetAvailableRooms(DateTime arrivalDate, DateTime departureDate, List<Reservation> activeReservations);
    }
}