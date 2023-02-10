using AutoMapper;
using RezervationTestCase.Common.Enums;
using RezervationTestCase.Dtos;
using RezervationTestCase.Dtos.BookingDtos;
using RezervationTestCase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.Bussines.Mapper.AutoMapper
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingListDto>().ReverseMap();
            CreateMap<Booking, BookingCreateDto>().ReverseMap();
            CreateMap<Booking, BookingUpdateDto>().ReverseMap();
            CreateMap<BookingListDto, BookingUpdateDto>().ReverseMap();

            //Booking Status Profile 
            CreateMap<BookingStatus, BookingStatusListDto>().ReverseMap();
        }
    }
}
