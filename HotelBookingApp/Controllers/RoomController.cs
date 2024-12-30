using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingApp.Controllers.ControllerInterfaces;
using HotelBookingApp.Services;
using HotelBookingApp.Services.ServiceInterfaces;
using HotelBookingApp.Utilities;

namespace HotelBookingApp.Controllers
{
    public class RoomController : IRoomController
    {
        IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public void AddRoom()
        {
            _roomService.CreateNewRoom();
        }

        public void GetRooms()
        {
            Console.Clear();
            var allRooms = _roomService.ReadAllRooms(); 
            DisplayEntities.ShowRoomTable(allRooms);
        }
    }
}
