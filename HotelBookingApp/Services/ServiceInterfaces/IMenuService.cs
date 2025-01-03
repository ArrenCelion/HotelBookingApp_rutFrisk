using HotelBookingApp.Utilities;

namespace HotelBookingApp.Services.ServiceInterfaces
{
    public interface IMenuService
    {
        DisplayMenu CreateReservationMenu();
        DisplayMenu CreateGuestMenu();
        DisplayMenu CreateMainMenu();
        DisplayMenu CreateRoomMenu();
    }
}