using AutoMapper;
using RezervationTestCase.Bussines.Interfaces;
using RezervationTestCase.Common;
using RezervationTestCase.Common.Enums;
using RezervationTestCase.DataAccess.Interfaces;
using RezervationTestCase.Dtos;
using RezervationTestCase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.Bussines.Services
{ 
    public class RoomService : IRoomService // room update ve create işlemleri db tarafında yapılacağı için Service clasıından kalıtım almıyourm.
    {
        readonly IUow _uow;
        readonly IMapper _mapper;

        public RoomService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IResponse<List<RoomListDto>>> GetAllAsync()
        {
            var data = await _uow.GetRepository<Room>().GetAllAsync();
            if(data == null)
                return new Response<List<RoomListDto>>(ResponseType.NotFound , "Bulunamadı", _mapper.Map<List<RoomListDto>>(data));
            return new Response<List<RoomListDto>>(ResponseType.Success, _mapper.Map<List<RoomListDto>>(data));
        }

        public async Task<IResponse<List<RoomListDto>>> GetAllAsync(Expression<Func<Room, bool>> filter)
        {
            var data = await _uow.GetRepository<Room>().GetAllAsync(filter);
            if (data == null)
                return new Response<List<RoomListDto>>(ResponseType.NotFound, "Bulunamadı", _mapper.Map<List<RoomListDto>>(data));
            return new Response<List<RoomListDto>>(ResponseType.Success, _mapper.Map<List<RoomListDto>>(data));
        }

        public async Task<IResponse<List<RoomListDto>>> GetAllAsync<TKey>(Expression<Func<Room, bool>> filter, Expression<Func<Room, TKey>> selector)
        {
            var data = await _uow.GetRepository<Room>().GetAllAsync(filter, selector);
            if (data == null)
                return new Response<List<RoomListDto>>(ResponseType.NotFound, "Bulunamadı", _mapper.Map<List<RoomListDto>>(data));
            return new Response<List<RoomListDto>>(ResponseType.Success,_mapper.Map<List<RoomListDto>>(data));

        }

        public IResponse<IQueryable<Room>> GetQueryable()
        {
            return new Response<IQueryable<Room>>(ResponseType.Success,_uow.GetRepository<Room>().GetQueryable());
        }
    }
}
