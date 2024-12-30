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

        public void UpdateGuest()
        {

        }

        public void RemoveGuest()
        {
            //Soft Delete
        }

        public void DeleteGuest()
        {
            //Hard Delete - kan bara göras om entiteten är soft deletad
        }
    }
}
