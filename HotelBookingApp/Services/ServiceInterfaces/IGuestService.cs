using HotelBookingApp.Models;

namespace HotelBookingApp.Services.ServiceInterfaces
{
    public interface IGuestService
    {
        void CreateNewGuest(Guest guest);
        void HardDeleteGuest(Guest guest);
        Guest GetGuestFromID(int guestId);
        List<Guest> ReadAllGuests();
        List<Guest> ReadActiveGuests();
        List<Guest> ReadInActiveGuests();
        void RemoveGuest(Guest guest);
        void UpdateGuest(Guest guest);
    }
}