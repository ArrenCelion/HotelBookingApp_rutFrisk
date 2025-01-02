using HotelBookingApp.Models;

namespace HotelBookingApp.Services.ServiceInterfaces
{
    public interface IReservationService
    {
        void CreateNewReservation();
        void DeleteReservation(Reservation reservation);
        List<Reservation> ReadActiveReservations();
        List<Reservation> ReadInactiveReservations();
        Reservation GetReservationFromID(int reservationId);
        void RemoveReservation(Reservation reservation);
        void UpdateReservation();
    }
}