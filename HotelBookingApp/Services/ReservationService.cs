using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingApp.Controllers.ControllerInterfaces;
using HotelBookingApp.Data;
using HotelBookingApp.Models;
using HotelBookingApp.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Services
{
    public class ReservationService : IReservationService
    {
        ApplicationDbContext _dbContext;
        IRoomController _roomController;
        public ReservationService(ApplicationDbContext dbContext, IRoomController roomController)
        {
            _dbContext = dbContext;
            _roomController = roomController;
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

        public List<Reservation> ReadAllReservations()
        {
            return _dbContext.Reservations
                .Include(r => r.Room)
                .Include(r => r.Guest)
                .ToList();
        }

        //Move to room service or room controller?
        public List<Room> GetAvailableRooms(DateTime arrivalDate, int lengthOfStay)
        {
            var departureDate = arrivalDate.AddDays(lengthOfStay);
            var activeReservations = ReadActiveReservations();
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
        public Room GetRoomChoice(DateTime arrivalDate, int lengthOfStay)
        {
            List<Room> availableRooms = GetAvailableRooms(arrivalDate, lengthOfStay);
            if (availableRooms == null)
            {
                Console.WriteLine("No rooms available for the selected dates");
                return null;
            }
            var roomChoice = _roomController.GetRoomOptionInput(availableRooms);
            return roomChoice;
        }

        public void UpdateReservation(Reservation reservation)
        {
            var reservationToUpdate = _dbContext.Reservations
                .SingleOrDefault(r => r.ReservationId == reservation.ReservationId);
            reservationToUpdate.ArrivalDate = reservation.ArrivalDate;
            reservationToUpdate.LengthOfStay = reservation.LengthOfStay;
            reservationToUpdate.Room = reservation.Room;
            reservation.Guest = reservation.Guest;
            reservation.WantsExtraBed = reservation.WantsExtraBed;
            reservation.IsActive = reservation.IsActive;
            _dbContext.SaveChanges();
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
