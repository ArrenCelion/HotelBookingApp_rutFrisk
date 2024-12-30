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
        public void CreateNewRoom()
        {

        }

        public List<Room> ReadAllRooms()
        {
            return _dbContext.Rooms.ToList();
        }

        public void UpdateRoom()
        {

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
