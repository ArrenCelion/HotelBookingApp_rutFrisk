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
    public class RoomController : IRoomController
    {
        IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public void AddRoom()
        {
            var room = new Room();
            room.RoomNumber = AnsiConsole.Ask<int>("Room number:");
            _roomService.ReadAllRooms().ForEach(r =>
            {
                if (r.RoomNumber == room.RoomNumber)
                {
                    AnsiConsole.MarkupLine("[red]Room number already exists. Please choose another number.[/]");
                    room.RoomNumber = AnsiConsole.Ask<int>("Room number:");
                }
            });

            room.RoomSize = AnsiConsole.Ask<int>("Room Size:");

            if (AnsiConsole.Confirm("Is it a Single Room?"))
            {
                room.IsSingle = true;
            }
            else
            {
                 room.IsSingle = false;
            }
            if (AnsiConsole.Confirm("Should the room be active and bookable right away?"))
            {
                room.IsActive = true;
            }
            else
            {
                room.IsActive = false;
            }

            _roomService.CreateNewRoom(room);
        }

        public void GetActiveRooms()
        {
            Console.Clear();
            var activeRooms = _roomService.ReadActiveRooms();
            DisplayEntities.ShowRoomTable(activeRooms);
        }

        public void GetInactiveRooms()
        {
            Console.Clear();
            var inactiveRooms = _roomService.ReadInActiveRooms();
            DisplayEntities.ShowRoomTable(inactiveRooms);
        }

        public Room GetRoomOptionInput(List<Room> rooms)
        {
            DisplayEntities.ShowRoomTable(rooms);
            var roomsArrayForDisplay = rooms.Select(r => r.RoomNumber.ToString()).ToArray();
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose Room")
                .AddChoices(roomsArrayForDisplay));

            var id = rooms.Single(x => x.RoomNumber.ToString() == option).RoomId;
            var room = _roomService.GetRoomFromID(id);

            return room;
        }

        public void UpdateRoom()
        {
            var allRooms = _roomService.ReadAllRooms();
            var room = GetRoomOptionInput(allRooms);
            if (AnsiConsole.Confirm("Update Room Number?"))
            {
                room.RoomNumber = AnsiConsole.Ask<int>("Enter new Room Number:");
                _roomService.ReadAllRooms().ForEach(r =>
                {
                    if (r.RoomNumber == room.RoomNumber)
                    {
                        AnsiConsole.MarkupLine("[red]Room number already exists. Please choose another number.[/]");
                        room.RoomNumber = AnsiConsole.Ask<int>("Room number:");
                    }
                });
            }
            if (AnsiConsole.Confirm("Update Room Size?"))
            {
                room.RoomSize = AnsiConsole.Ask<int>("Enter new Room Size:");
            }
            if (AnsiConsole.Confirm("Update Room Type?"))
            {
                room.IsSingle = AnsiConsole.Confirm("Is the room a single room?");
            }
            if (AnsiConsole.Confirm("Update Room Status?"))
            {
                room.IsActive = AnsiConsole.Confirm("Is the room active and bookable?");
            }
            _roomService.UpdateRoom(room);
        }

        public void RemoveRoom()
        {
            var activeRooms = _roomService.ReadActiveRooms();
            var room = GetRoomOptionInput(activeRooms);
            if (AnsiConsole.Confirm("Are you sure you want to remove this room? This will inactivate the room so that it's not bookable"))
            {
               room.IsActive = false;
            }

            _roomService.RemoveRoom(room);
        }

        public void DeleteRoom()
        {
            var inactiveRooms = _roomService.ReadInActiveRooms();
            var room = GetRoomOptionInput(inactiveRooms);
            if (AnsiConsole.Confirm("Are you sure you want to delete this room? This will permanently delete the room from the database and it will not be recoverable."))
            {
                _roomService.HardDeleteRoom(room);
            }

        }
    }
}
