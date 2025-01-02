using HotelBookingApp.Models;

namespace HotelBookingApp.Controllers.ControllerInterfaces
{
    public interface IRoomController
    {
        void AddRoom();
        void DeleteRoom();
        Room GetRoomOptionInput(List<Room> rooms);
        void GetActiveRooms();
        void UpdateRoom();
        void RemoveRoom();
        void GetInactiveRooms();
    }
}