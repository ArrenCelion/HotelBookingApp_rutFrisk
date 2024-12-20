using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public int RoomSize { get; set; }
        public bool IsSingle {  get; set; }
        public bool IsActive { get; set; }

    }
}
