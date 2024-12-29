using HotelBookingApp.Utilities;

namespace HotelBookingApp.Services.ServiceInterfaces
{
    public interface IMenuService
    {
        DisplayMenu CreateBookingMenu();
        DisplayMenu CreateGuestMenu();
        DisplayMenu CreateMainMenu();
        DisplayMenu CreateRoomMenu();
    }
}