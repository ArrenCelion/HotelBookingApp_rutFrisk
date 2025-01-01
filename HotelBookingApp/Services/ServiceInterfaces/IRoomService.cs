using HotelBookingApp.Models;

namespace HotelBookingApp.Services.ServiceInterfaces
{
    public interface IRoomService
    {
        void CreateNewRoom();
        void DeleteRoom();
        List<Room> ReadAllRooms();
        Room GetRoomFromID(int roomId);
        void RemoveRoom();
        void UpdateRoom(Room room);
    }
}