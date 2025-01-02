using HotelBookingApp.Data;
using HotelBookingApp.Models;
using HotelBookingApp.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.Services
{
    public class GuestService : IGuestService
    {
        ApplicationDbContext _dbContext;
        public GuestService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateNewGuest(Guest guest)
        {
            _dbContext.Add<Guest>(guest);
            _dbContext.SaveChanges();
        }

        public List<Guest> ReadAllGuests()
        {
            return _dbContext.Guests.ToList();
        }
        public List<Guest> ReadInActiveGuests()
        {
            return _dbContext.Guests.Where(g => g.IsActive == false).ToList();
        }
        public List<Guest> ReadActiveGuests()
        {
            return _dbContext.Guests.Where(g => g.IsActive == true).ToList();
        }
        public Guest GetGuestFromID(int guestId)
        {
            return _dbContext.Guests.SingleOrDefault(g => g.GuestId == guestId);
        }
        public void UpdateGuest(Guest guest)
        {
            var guestToUpdate = _dbContext.Guests
                .SingleOrDefault(g => g.GuestId == guest.GuestId);
            guestToUpdate.FirstName = guest.FirstName;
            guestToUpdate.LastName = guest.LastName;
            guestToUpdate.Email = guest.Email;
            guestToUpdate.PhoneNumber = guest.PhoneNumber;
            guestToUpdate.DateOfBirth = guest.DateOfBirth;
            guestToUpdate.Address = guest.Address;
            guestToUpdate.PostalCode = guest.PostalCode;
            guestToUpdate.City = guest.City;
            guestToUpdate.IsActive = guest.IsActive;
            _dbContext.SaveChanges();

        }

        public void RemoveGuest(Guest guest)
        {
            //Soft Delete
        }

        public void HardDeleteGuest(Guest guest)
        {
            //Hard Delete - kan bara göras om entiteten är soft deletad
        }
    }
}
