using RezervationTestCase.Dtos.BookingDtos;
using RezervationTestCase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.Bussines.Interfaces
{
    public interface IBookingService : IService<BookingCreateDto,BookingListDto,BookingUpdateDto ,Booking> , IQueryable<BookingListDto,Booking>
    {

    }
}
