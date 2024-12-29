using HotelBookingApp.Services;

namespace HotelBookingApp.Controllers
{
    public interface IMenuController
    {
        void RunBookingMenu();
        void RunGuestMenu();
        void RunMainMenu();
        void RunRoomMenu();
    }
}