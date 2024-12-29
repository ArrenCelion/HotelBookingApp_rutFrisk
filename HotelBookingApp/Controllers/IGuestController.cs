using HotelBookingApp.Models;

namespace HotelBookingApp.Controllers
{
    public interface IGuestController
    {
        void AddGuest();
        void CreateGuestInputValidation(Guest newGuest);
        void GetGuests();
    }
}