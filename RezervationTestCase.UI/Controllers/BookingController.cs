using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RezervationTestCase.Bussines.Extnesions;
using RezervationTestCase.Bussines.Interfaces;
using RezervationTestCase.Common.Enums;
using RezervationTestCase.Dtos.BookingDtos;
using RezervationTestCase.UI.Models;

namespace RezervationTestCase.UI.Controllers
{
    public class BookingController : Controller
    {
        readonly IRoomService _roomService;
        readonly IBookingService _bookingService;
        readonly IValidator<BookingSearchModel> _validator;
        readonly IMapper _mapper;

        public static List<BookingCreateDto> bookingList = new();


        public BookingController(IRoomService roomService, IBookingService bookingService, IValidator<BookingSearchModel> validator, IMapper mapper)
        {
            _roomService = roomService;
            _bookingService = bookingService;
            _validator = validator;
            _mapper = mapper;
        }
        [HttpGet("/[controller]/search")]
        public async Task<IActionResult> Search(BookingSearchModel model)
        {
            var result = _validator.Validate(model);
            if (result.IsValid)
            {
                if (model.NumberOfVisitor == 0)
                    return View();
                bookingList.Clear();//yeni arama yapılmadan önce boşaltılsın.

                var response = _roomService.GetQueryable();
                response.Data.Include(x => x.Bookings).ToList();

                if (response.ResponseType == ResponseType.NotFound)
                {
                    ViewBag.Message = response.Message;
                    return View();
                }

                foreach (var room in response.Data) // Odanın rezervasyona uygun olup olmadığı sorgulanıyor.
                {
                    bool isOk = true;
                    if (room.Bookings!=null)
                        foreach (var booking in room.Bookings)
                        {
                            if (!room.CheckAvaiable(model.EntryDate, model.ExitDate, booking.EntryDate, booking.ExitDate , booking.BookingStatusId))
                                isOk = false;
                        }
                    if (isOk)
                        bookingList.Add(
                        new BookingCreateDto(model.NumberOfVisitor, model.EntryDate, model.ExitDate, room.DailyPrice, room.Id));
                }

                return View(bookingList.OrderBy(x => x.TotalPrice).ToList());
            }
            foreach (var error in result.GetValidationErrors())
            {
                ModelState.AddModelError(error.ErrorType, error.ErrorMessage);
            }
            return View();

        }
        [HttpGet("[controller]/[action]/{id}")]
        public async Task<IActionResult> Create(int id)
        {
            var model = bookingList.Where(x => x.RoomId == id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookingCreateDto model)
        {
            model.BookingDate = DateTime.Now;
            model.BookingStatusId = (int)BookingStatusType.Waiting; // Rezervasyonu Drekt bekliyor olarak atama yapıyoruz
            var response = await _bookingService.CreateAsync(model);
            if (response.ResponseType == ResponseType.Error)
                ViewBag.Message = "Bir Problem Oluştu.";
            ViewBag.Message = "Rezervasyon oluşturuldu.";
            return RedirectToAction("Search");
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var data = _bookingService.GetQueryable(id);
            if (data != null)
                return View(data);
            return NotFound();

        }
        [HttpPost]
        public async Task<IActionResult> Cancel(BookingListDto dto)
        {
            dto.BookingStatusId = (int)BookingStatusType.Cancelled; // iptal işlemi yapılıyor.
            var mappedData = _mapper.Map<BookingUpdateDto>(dto);
            var response = await _bookingService.UpdateAsync(mappedData);
            if (response.ResponseType == ResponseType.Success)
            {
                return Redirect($"/Booking/Detail/{dto.Id}");
            }
            return RedirectToAction("Search");
        }
    }
}
