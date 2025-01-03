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
    public class ReservationService : IReservationService
    {
        ApplicationDbContext _dbContext;
        public ReservationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateNewReservation(Reservation reservation)
        {
            _dbContext.Add(reservation);
            _dbContext.SaveChanges();
        }

        public List<Reservation> ReadActiveReservations()
        {
            return _dbContext.Reservations
                .Include(r => r.Room)
                .Include(r => r.Guest)
                .Where(r => r.IsActive == true)
                .ToList();
        }

        public List<Reservation> ReadInactiveReservations()
        {
            return _dbContext.Reservations
                .Include(r => r.Room)
                .Include(r => r.Guest)
                .Where(r => r.IsActive == false)
                .ToList();
        }
    
        public List<Room> GetAvailableRooms(DateTime arrivalDate, DateTime departureDate, List<Reservation> activeReservations)
        {
            List<Room> availableRooms = _dbContext.Rooms.ToList();
            foreach (Reservation r in activeReservations)
            {
                if (arrivalDate < r.ArrivalDate.AddDays(r.LengthOfStay) && departureDate > r.ArrivalDate)
                {
                    // room is not available
                    availableRooms.Remove(r.Room);
                }
            }
            return availableRooms;
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
            _dbContext.SaveChanges();
        }

        public void HardDeleteReservation(Reservation reservation)
        {
            _dbContext.Remove(reservation);
            _dbContext.SaveChanges();
        }
    }
}
