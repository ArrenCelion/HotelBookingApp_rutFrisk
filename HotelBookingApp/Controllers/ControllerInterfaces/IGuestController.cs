using HotelBookingApp.Models;

namespace HotelBookingApp.Controllers.ControllerInterfaces
{
    public interface IGuestController
    {
        void AddGuest();
        void CreateGuestInputValidation(Guest newGuest);
        void GetGuests();
    }
}