using HotelBookingApp.Models;

namespace HotelBookingApp.Controllers.ControllerInterfaces
{
    public interface IRoomController
    {
        void AddRoom();
        void DeleteRoom();
        Room GetRoomOptionInput();
        void GetRooms();
        void UpdateRoom();
    }
}