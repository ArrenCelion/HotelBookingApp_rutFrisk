using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingApp.Data;
using HotelBookingApp.Models;
using HotelBookingApp.Services.ServiceInterfaces;

namespace HotelBookingApp.Services
{
    public class ReservationService : IReservationService
    {
        ApplicationDbContext _dbContext;
        public ReservationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateNewReservation()
        {

        }

        public List<Reservation> ReadActiveReservations()
        {
            return _dbContext.Reservations.Where(r => r.IsActive == true).ToList();
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
