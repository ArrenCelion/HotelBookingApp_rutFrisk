using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingApp.Controllers.ControllerInterfaces;
using HotelBookingApp.Services.ServiceInterfaces;
using HotelBookingApp.Utilities;

namespace HotelBookingApp.Controllers
{
    public class ReservationController : IReservationController
    {
        IReservationService _reservationService;
        public ReservationController(IReservationService reservationService) 
        {
            _reservationService = reservationService;
        }
        public void AddReservation()
        {
            //How to connect the reservation to guest and room?
            //using spectre calendar to select 
        }

        public void GetActiveReservations()
        {
            var activeReservations = _reservationService.ReadActiveReservations();
            DisplayEntities.ShowReservationTable(activeReservations);

        }
    }
}
