using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.Services
{
    public class RoomService : IRoomService
    {
        ApplicationDbContext _dbContext;
        public RoomService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateNewRoom()
        {

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
            _dbContext.SaveChanges();
        }

        public void RemoveRoom()
        {
            //Soft Delete
        }

        public void DeleteRoom()
        {
            //Hard Delete - kan bara göras om entiteten är soft deletad
        }
    }
}
