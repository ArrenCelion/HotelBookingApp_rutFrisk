namespace HotelBookingApp.Services.ServiceInterfaces
{
    public interface IReservationService
    {
        void CreateNewReservation();
        void DeleteReservation();
        void ReadAllReservations();
        void RemoveReservation();
        void UpdateReservation();
    }
}