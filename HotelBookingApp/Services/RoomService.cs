using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingApp.Services.ServiceInterfaces;

namespace HotelBookingApp.Services
{
    public class RoomService : IRoomService
    {
        public void CreateNewRoom()
        {

        }

        public void ReadAllRooms()
        {

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
