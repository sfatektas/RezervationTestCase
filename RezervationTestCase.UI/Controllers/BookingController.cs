using Microsoft.AspNetCore.Mvc;
using RezervationTestCase.Bussines.Interfaces;
using RezervationTestCase.Common.Enums;
using RezervationTestCase.Dtos.BookingDtos;
using RezervationTestCase.UI.Models;

namespace RezervationTestCase.UI.Controllers
{
    public class BookingController : Controller
    {
        readonly IRoomService _roomService;
        

        public BookingController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("/[controller]/search")]
        public async Task<IActionResult> Search([FromQuery] int visitor, DateTime entryDate, DateTime exitDate )
        {
            
            
            if(visitor == 0)
                return View();
            var response = await _roomService.GetAllAsync(x=>x.IsActive == true);
            if(response.ResponseType==ResponseType.NotFound)
            {
                ViewBag.Message = response.Message;
                return View();
            }
            List<BookingCreateDto> bookingList = new();
            foreach (var item in response.Data)
            {
                bookingList.Add(
                    new BookingCreateDto( visitor ,entryDate ,exitDate , item.DailyPrice));
            }
            ViewBag.Model = new BookingSearchModel
            {
                EntryDate = entryDate,
                ExitDate = exitDate,
                NumberOfVisitor = visitor
            };
            return View(bookingList.OrderBy(x=>x.TotalPrice).ToList());
        }
    }
}
