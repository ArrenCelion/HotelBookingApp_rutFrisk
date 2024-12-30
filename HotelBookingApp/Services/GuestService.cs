using HotelBookingApp.Data;
using HotelBookingApp.Models;
using HotelBookingApp.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.Services
{
    public class GuestService : IGuestService
    {
        public GuestService()
        {
            
        }
        public void CreateNewGuest(Guest guest)
        {



        }

        public void ReadAllGuests()
        {

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
