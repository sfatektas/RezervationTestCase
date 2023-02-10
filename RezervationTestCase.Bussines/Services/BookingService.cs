using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RezervationTestCase.Bussines.Interfaces;
using RezervationTestCase.DataAccess.Interfaces;
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
        private readonly IUow uow;
        private readonly IMapper _mapper;

        public BookingServices(IValidator<BookingCreateDto> validator, IUow uow , IMapper mapper) : base(uow,mapper,validator)
        {
            this.uow = uow;
            this._mapper = mapper;
        }

        public List<BookingListDto> GetQueryable()
        {
            return _mapper.Map<List<BookingListDto>>(uow.GetRepository<Booking>().GetQueryable().Include(x => x.BookingStatus).ToList());
        }

        public BookingListDto GetQueryable(int id)
        {
            var data = uow.GetRepository<Booking>().GetQueryable().Where(x => x.Id == id).Include(x => x.BookingStatus).FirstOrDefault();
            return _mapper.Map<BookingListDto>(data);

        }
    }
}
