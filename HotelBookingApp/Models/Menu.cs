using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.Models
{
    public class Menu
    {
        public int MenuId { get; set; }

        [Required]
        [MaxLength(100)]
        public string MenuName { get; set; }
        
        [Required]
        public string MenuPrompt { get; set; }
    }
}
