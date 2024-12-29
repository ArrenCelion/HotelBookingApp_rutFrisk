using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingApp.Services.ServiceInterfaces;

namespace HotelBookingApp.Services
{
    public class ReservationService : IReservationService
    {
        public void CreateNewReservation()
        {

        }

        public void ReadAllReservations()
        {

        }

        public void UpdateReservation()
        {

        }

        public void RemoveReservation()
        {
            //Soft Delete
        }

        public void DeleteReservation()
        {
            //Hard Delete - kan bara göras om entiteten är soft deletad
        }
    }
}
