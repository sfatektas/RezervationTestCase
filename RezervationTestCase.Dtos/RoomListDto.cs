using RezervationTestCase.Dtos.BookingDtos;
using RezervationTestCase.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.Dtos
{
    public class RoomListDto : IListDto
    {
        public int Id { get; set; }

        public int Capacity { get; set; }

        public decimal DailyPrice { get; set; }

        public bool IsActive { get; set; }

        public List<BookingListDto> Bookings { get; set; }
    }
}
