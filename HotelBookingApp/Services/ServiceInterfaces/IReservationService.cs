using HotelBookingApp.Models;

namespace HotelBookingApp.Services.ServiceInterfaces
{
    public interface IReservationService
    {
        void CreateNewReservation(Reservation reservation);
        void HardDeleteReservation(Reservation reservation);
        List<Reservation> ReadActiveReservations();
        List<Reservation> ReadInactiveReservations();
        List<Reservation> ReadAllReservations();
        Reservation GetReservationFromID(int reservationId);
        void RemoveReservation(Reservation reservation);
        void UpdateReservation(Reservation reservation);
        List<Room> GetAvailableRooms(DateTime arrivalDate, int lengthOfStay);
        Room GetRoomChoice(DateTime arrivalDate, int lengthOfStay);
    }
}