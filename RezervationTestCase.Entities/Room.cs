using RezervationTestCase.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.Entities
{
    public class Room : BaseEntity
    {
        public int Capacity { get; set; }

        public decimal DailyPrice { get; set; }

        public bool IsActive { get; set; }

        public List<Booking> Bookings { get; set; }

        public bool CheckAvaiable(DateTime searchEntryDate, DateTime searchExitDate, DateTime bookingEntryDate, DateTime bookingExitDate, int bookingStatusId)
        {
            if (bookingStatusId != (int) BookingStatusType.Cancelled) //rezervasyon iptal ise gözardı edilsin ...
                if ((searchEntryDate >= bookingEntryDate && searchEntryDate <= bookingExitDate)
                || (searchEntryDate <= bookingEntryDate && searchExitDate >= bookingExitDate)
                || (searchExitDate >= bookingEntryDate && searchExitDate <= bookingExitDate))
                    return false;
            return true;
        }
    }
}
