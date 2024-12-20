using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApp.Models
{
    internal class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime DueDate { get; set; }
        public int InvoiceAmount { get; set; }
        public bool IsPaid { get; set; }
    }
}
