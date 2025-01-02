using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingApp.Data;
using HotelBookingApp.Models;
using HotelBookingApp.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Services
{
    public class RoomService : IRoomService
    {
        ApplicationDbContext _dbContext;
        public RoomService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateNewRoom(Room room)
        {
            _dbContext.Rooms.Add(room);
            _dbContext.SaveChanges();
        }

        public List<Room> ReadAllRooms()
        {
            return _dbContext.Rooms.ToList();
        }

        public Room GetRoomFromID(int roomId)
        {
           return _dbContext.Rooms.SingleOrDefault(r => r.RoomId == roomId);
        }

        public void UpdateRoom(Room room)
        {
            var roomToUpdate = _dbContext.Rooms
                .SingleOrDefault(r => r.RoomId == room.RoomId);

            roomToUpdate.RoomNumber = room.RoomNumber;
            roomToUpdate.RoomSize = room.RoomSize;
            roomToUpdate.IsSingle = room.IsSingle;
            roomToUpdate.IsActive = room.IsActive;
            _dbContext.SaveChanges();
        }

        public void RemoveRoom(Room room)
        {
            var roomToRemove = _dbContext.Rooms
                .SingleOrDefault(r => r.RoomId == room.RoomId);
            roomToRemove.IsActive = room.IsActive;
            _dbContext.SaveChanges();
        }

        public List<Room> ReadInActiveRooms()
        {
            return _dbContext.Rooms.Where(r => r.IsActive == false).ToList();
        }

        public List<Room> ReadActiveRooms()
        {
            return _dbContext.Rooms.Where(r => r.IsActive == true).ToList();
        }

        public void HardDeleteRoom(Room room)
        {
            _dbContext.Remove(room);
            _dbContext.SaveChanges();
        }
    }
}
