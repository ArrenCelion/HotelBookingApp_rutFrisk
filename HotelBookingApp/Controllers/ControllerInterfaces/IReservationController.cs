namespace HotelBookingApp.Controllers.ControllerInterfaces
{
    public interface IReservationController
    {
        void AddReservation();
        void GetActiveReservations();
        void GetInactiveReservations();
        void RemoveReservation();
        void DeleteReservation();

    }
}