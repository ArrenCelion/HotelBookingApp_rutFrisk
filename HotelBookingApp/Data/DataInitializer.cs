using Bogus;
using HotelBookingApp.Data;
using HotelBookingApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.Data
{
    public class DataInitializer : IDataInitializer
    {
        ApplicationDbContext _dbContext;
        public DataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void MigrateAndSeed()
        {
            _dbContext.Database.Migrate();
            SeedGuests();
            SeedRooms();
            _dbContext.SaveChanges();
        }

        private void SeedRooms()
        {
            if (!_dbContext.Rooms.Any(r => r.RoomId == 1))
            {
                _dbContext.Add(new Room
                {
                    RoomNumber = 101,
                    RoomSize = 15,
                    IsActive = true,
                    IsSingle = true
                });
            }

            if (!_dbContext.Rooms.Any(r => r.RoomId == 2))
            {
                _dbContext.Add(new Room
                {
                    RoomNumber = 102,
                    RoomSize = 20,
                    IsActive = true,
                    IsSingle = false
                });
            }

            if (!_dbContext.Rooms.Any(r => r.RoomId == 3))
            {
                _dbContext.Add(new Room
                {
                    RoomNumber = 103,
                    RoomSize = 12,
                    IsActive = true,
                    IsSingle = true
                });
            }

            if (!_dbContext.Rooms.Any(r => r.RoomId == 4))
            {
                _dbContext.Add(new Room
                {
                    RoomNumber = 104,
                    RoomSize = 25,
                    IsActive = true,
                    IsSingle = false
                });
            }
        }

        private void SeedGuests()
        {
            if (!_dbContext.Guests.Any(g => g.GuestId == 10))
            {
                var guestFaker = new Faker<Guest>()
                    .RuleFor(g => g.FirstName, f => f.Name.FirstName())
                    .RuleFor(g => g.LastName, f => f.Name.LastName())
                    .RuleFor(g => g.Email, f => f.Internet.Email())
                    .RuleFor(g => g.PhoneNumber, f => f.Phone.PhoneNumber())
                    .RuleFor(g => g.DateOfBirth, f => f.Date.Past(100, DateTime.Now.AddYears(-18)))
                    .RuleFor(g => g.Address, f => f.Address.StreetAddress())
                    .RuleFor(g => g.PostalCode, f => f.Address.ZipCode())
                    .RuleFor(g => g.City, f => f.Address.City())
                    .RuleFor(g => g.IsActive, f => f.Random.Bool(0.9f));

                guestFaker.Generate(10).ForEach(g => _dbContext.Add(g));
            }
        }
    }
}
