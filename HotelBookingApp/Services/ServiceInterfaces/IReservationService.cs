using HotelBookingApp.Models;

namespace HotelBookingApp.Services.ServiceInterfaces
{
    public interface IReservationService
    {
        void CreateNewReservation();
        void DeleteReservation();
        List<Reservation> ReadActiveReservations();
        void RemoveReservation();
        void UpdateReservation();
    }
}