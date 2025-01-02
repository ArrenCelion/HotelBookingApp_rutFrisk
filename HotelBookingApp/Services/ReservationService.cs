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

        public List<Reservation> ReadInactiveReservations()
        {
            return _dbContext.Reservations.Where(r => r.IsActive == false).ToList();
        }

        public void UpdateReservation()
        {

        }
       public Reservation GetReservationFromID(int reservationId)
        {
            return _dbContext.Reservations.SingleOrDefault(r => r.ReservationId == reservationId);
        }
        public void RemoveReservation(Reservation reservation)
        {
            var reservationToRemove = _dbContext.Reservations
                .SingleOrDefault(r => r.ReservationId == reservation.ReservationId);
            reservationToRemove.IsActive = reservation.IsActive;
        }

        public void HardDeleteReservation(Reservation reservation)
        {
            _dbContext.Remove(reservation);
            _dbContext.SaveChanges();
        }
    }
}
