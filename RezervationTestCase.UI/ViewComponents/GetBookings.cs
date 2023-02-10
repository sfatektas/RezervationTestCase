using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RezervationTestCase.Bussines.Interfaces;
using RezervationTestCase.DataAccess.Interfaces;
using RezervationTestCase.Dtos.BookingDtos;
using RezervationTestCase.Entities;

namespace RezervationTestCase.UI.ViewComponents
{
    public class GetBookings : ViewComponent
    {
        readonly IUow _uow;
        readonly IMapper _mapper;


        public GetBookings(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        
        {
            var data = await _uow.GetRepository<Booking>().GetQueryable().Include(x => x.BookingStatus).OrderBy(x => x.BookingStatusId).OrderByDescending(x => x.BookingDate).ToListAsync();
            if(data.Count != 0)
                return View(_mapper.Map<List<BookingListDto>>(data));
            return View(new List<BookingListDto>());
        }
    }
}
