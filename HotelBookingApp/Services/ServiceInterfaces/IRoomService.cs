using HotelBookingApp.Models;

namespace HotelBookingApp.Services.ServiceInterfaces
{
    public interface IRoomService
    {
        void CreateNewRoom(Room room);
        void HardDeleteRoom(Room room);
        List<Room> ReadAllRooms();
        Room GetRoomFromID(int roomId);
        void RemoveRoom(Room room);
        void UpdateRoom(Room room);
        List<Room> ReadInActiveRooms();
        List<Room> ReadActiveRooms();
    }
}