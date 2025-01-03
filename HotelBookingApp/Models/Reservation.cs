using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int LengthOfStay { get; set; }
        public bool IsActive { get; set; }
        public bool WantsExtraBed { get; set; }

        [Required]
        public Room Room { get; set; }
        [Required]
        public Guest Guest { get; set; }

    }
}
