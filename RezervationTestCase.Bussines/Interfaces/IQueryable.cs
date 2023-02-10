using RezervationTestCase.Dtos.Interfaces;
using RezervationTestCase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.Bussines.Interfaces
{
    public interface IQueryable<ListDto,T> where T : BaseEntity
        where ListDto : class,IListDto
    {
        List<ListDto> GetQueryable();
        ListDto GetQueryable(int id);

    }
}
