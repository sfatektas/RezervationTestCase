using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.Entities
{
    public class BookingStatus : BaseEntity
    {
        public string Defination { get; set; }

        public List<Booking> Bookings { get; set; }

    }
}
