using RezervationTestCase.Dtos.CustomerDtos;
using RezervationTestCase.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.Dtos.BookingDtos
{
    public class BookingListDto : IListDto
    {
        public int Id { get; set; }

        public CustomerListDto Customer { get; set; }

        public int CustomerId { get; set; }

        public RoomListDto Room { get; set; }

        public int RoomId { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime ExitDate { get; set; }

        public BookingStatusListDto BookingStatus { get; set; }

        public int BookingStatusId { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime BookingDate { get; set; }
    }
}
