using RezervationTestCase.Bussines.Services;
using RezervationTestCase.Common;
using RezervationTestCase.Common.Enums;
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
    public interface IService<CreateDto, ListDto, UpdateDto, T> where CreateDto : class, ICreateDto
        where ListDto : class, IListDto
        where UpdateDto : class, IUpdateDto
        where T : BaseEntity
    {
        Task<IResponse<CreateDto>> CreateAsync(CreateDto model);

        Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto model);

        Task<IResponse<ListDto>> GetByIdAsync(int id);

        Task<IResponse<ListDto>> GetByFilterAsync(Expression<Func<T, bool>> filter);

        Task<IResponse<List<ListDto>>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector ,OrderByType orderType);

        //Task<IResponse> RemoveAsync(ListDto dto);

        Task<IResponse<List<ListDto>>> GetAllAsync();

        Task<IResponse<List<ListDto>>> GetAllAsync(Expression<Func<T, bool>> filter);
    }
}
