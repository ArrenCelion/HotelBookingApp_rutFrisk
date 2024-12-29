using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus.Extensions.UnitedKingdom;
using HotelBookingApp.Controllers.ControllerInterfaces;
using HotelBookingApp.Models;
using HotelBookingApp.Services;
using HotelBookingApp.Services.ServiceInterfaces;
using HotelBookingApp.Utilities;
using Spectre.Console;

namespace HotelBookingApp.Controllers
{
    public class RoomController
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

        public Room GetRoomOptionInput()
        {
            var rooms = _roomService.ReadAllRooms();
            var roomsArrayForDisplay = rooms.Select(r => r.RoomNumber.ToString()).ToArray();
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose Room to update")
                .AddChoices(roomsArrayForDisplay));

            var id = rooms.Single(x => x.RoomNumber.ToString() == option).RoomId;
            var room = _roomService.GetRoomFromID(id);

            return room;
        }

        public void UpdateRoom()
        {
            var room = GetRoomOptionInput();
            if(AnsiConsole.Confirm("Update Room Number?"))
            {
                room.RoomNumber = AnsiConsole.Ask<int>("Enter new Room Number:");
            }
            if (AnsiConsole.Confirm("Update Room Size?"))
            {
                room.RoomSize = AnsiConsole.Ask<int>("Enter new Room Size:");
            }
            if (AnsiConsole.Confirm("Update Room Type?"))
            {
                room.IsSingle = AnsiConsole.Confirm("Is the room a single room?");
            }
            _roomService.UpdateRoom(room);
        }

        public void DeleteRoom()
        {

        }
    }
}
