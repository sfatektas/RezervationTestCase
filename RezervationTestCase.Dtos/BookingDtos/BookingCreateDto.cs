using RezervationTestCase.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.Dtos.BookingDtos
{
    public class BookingCreateDto : ICreateDto
    {
        public BookingCreateDto()
        {

        }
        public BookingCreateDto(int numberOfCustomer , DateTime entryDate , DateTime exitDate , decimal dailyRoomPrice , int roomId )
        {
            TotalPrice =  this.CalculateNetPrice(numberOfCustomer, entryDate, exitDate , dailyRoomPrice);
            EntryDate = entryDate;
            ExitDate = exitDate;
            NumberOfVisitor = numberOfCustomer;
            RoomId = roomId;
        }

        public string CustomerName { get; set; }

        public RoomListDto Room { get; set; }

        public int RoomId { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime ExitDate { get; set; }

        public int NumberOfVisitor { get; set; }

        public BookingStatusListDto BookingStatus { get; set; }

        public int BookingStatusId { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime BookingDate { get; set; }

        public decimal CalculateNetPrice(int numberOfCustomer, DateTime entryDate, DateTime exitDate, decimal dailyRoomPrice)
        {
            var range = exitDate.AddDays(1) - entryDate; /*eğer 1 günlük konaklama yapılırsa 1 gün farkı olması için çıkış tarihine 1 gün eklendi */

            switch (numberOfCustomer)  // default setting;
            {
                case 1:
                    TotalPrice = dailyRoomPrice * 7 / 10; // default setting;
                    break;
                case 2:
                    TotalPrice = dailyRoomPrice;
                    break;
                case 3:
                    TotalPrice = dailyRoomPrice * 13 / 10;
                    break;
                default:
                    break;
            }

            for (int i = 1; i < range.Days; i++) // defaul olarak yukarıda ilk günü alıyoruz o yüzden 1 gün eksik hesap yapmalıyız.
            {
                if (entryDate.AddDays(i).DayOfWeek == DayOfWeek.Saturday || entryDate.AddDays(i).DayOfWeek == DayOfWeek.Sunday) 
                    TotalPrice += dailyRoomPrice * 13 / 10; // eğer hafta sonu ise %30 zamlı olarak günlük fiyatı hesaplarız.
                else
                    TotalPrice += dailyRoomPrice;

            }
            return TotalPrice;
        }

    }
}
