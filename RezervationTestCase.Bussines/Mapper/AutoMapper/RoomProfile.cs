using AutoMapper;
using RezervationTestCase.Dtos;
using RezervationTestCase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.Bussines.Mapper.AutoMapper
{
    public class RoomProfile :Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomListDto>().ReverseMap();

        }
    }
}
