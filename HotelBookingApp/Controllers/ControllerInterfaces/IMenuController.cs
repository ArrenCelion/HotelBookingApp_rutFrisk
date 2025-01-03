using HotelBookingApp.Services;

namespace HotelBookingApp.Controllers.ControllerInterfaces
{
    public interface IMenuController
    {
        void RunReservationMenu();
        void RunGuestMenu();
        void RunMainMenu();
        void RunRoomMenu();
    }
}