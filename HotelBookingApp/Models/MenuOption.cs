using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.Models
{
    internal class MenuOption
    {
        public int MenuOptionId { get; set; }

        [Required]
        [MaxLength(100)]
        public string OptionName { get; set; }

        //public int MenuId 
    }
}
