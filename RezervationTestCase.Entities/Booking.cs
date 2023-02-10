using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.Entities
{
    public class Booking : BaseEntity
    {
        //public Customer Customer { get; set; } customer tablosu silindi sadece kullanıcının adını tutacağım

        //public int CustomerId { get; set; }
        public string CustomerName { get; set; }    

        public Room Room { get; set; }

        public int RoomId { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime ExitDate { get; set; }

        public int NumberOfVisitor { get; set; }

        public BookingStatus BookingStatus { get; set; }

        public int BookingStatusId { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime BookingDate { get; set; }



    }

}
