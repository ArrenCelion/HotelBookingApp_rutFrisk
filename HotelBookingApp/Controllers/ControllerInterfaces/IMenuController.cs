using HotelBookingApp.Services;

namespace HotelBookingApp.Controllers.ControllerInterfaces
{
    public interface IMenuController
    {
        void RunBookingMenu();
        void RunGuestMenu();
        void RunMainMenu();
        void RunRoomMenu();
    }
}