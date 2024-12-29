using HotelBookingApp.Models;

namespace HotelBookingApp.Services.ServiceInterfaces
{
    public interface IGuestService
    {
        void CreateNewGuest(Guest guest);
        void DeleteGuest();
        void ReadAllGuests();
        void RemoveGuest();
        void UpdateGuest();
    }
}