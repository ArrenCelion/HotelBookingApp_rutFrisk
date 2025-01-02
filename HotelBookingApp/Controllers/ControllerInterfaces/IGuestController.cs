using HotelBookingApp.Models;

namespace HotelBookingApp.Controllers.ControllerInterfaces
{
    public interface IGuestController
    {
        void AddGuest();
        void DeleteGuest();
        void UpdateGuest();
        void RemoveGuest();
        Guest GetGuestOptionInput(List<Guest> guests);
        void GetActiveGuests();
        void GetInactiveGuests();
        void SearchGuest();
        void CreateGuestInputValidation(Guest newGuest);
    }
}