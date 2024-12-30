using HotelBookingApp.Models;

namespace HotelBookingApp.Services.ServiceInterfaces
{
    public interface IRoomService
    {
        void CreateNewRoom();
        void DeleteRoom();
        List<Room> ReadAllRooms();
        void RemoveRoom();
        void UpdateRoom();
    }
}