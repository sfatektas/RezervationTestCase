using FluentValidation;
using RezervationTestCase.Bussines.Interfaces;
using RezervationTestCase.Dtos.BookingDtos;
using RezervationTestCase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.Bussines.Services
{
    public class BookingServices : Service<BookingCreateDto,BookingListDto ,BookingUpdateDto , Booking> , IBookingService
    {
        readonly IValidator<BookingCreateDto> _validator;

        public BookingServices(IValidator<BookingCreateDto> validator) : base(validator)
        {
        }
    }
}
