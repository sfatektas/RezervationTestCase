using RezervationTestCase.Common;
using RezervationTestCase.Dtos;
using RezervationTestCase.Dtos.Interfaces;
using RezervationTestCase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.Bussines.Interfaces
{
    public interface IRoomService 
    {
        Task<IResponse<List<RoomListDto>>> GetAllAsync();

        Task<IResponse<List<RoomListDto>>> GetAllAsync(Expression<Func<Room, bool>> filter);

        Task<IResponse<List<RoomListDto>>> GetAllAsync<TKey>(Expression<Func<Room, bool>> filter , Expression<Func<Room , TKey>> selector);

        IResponse<IQueryable<Room>> GetQueryable();
    }
}
