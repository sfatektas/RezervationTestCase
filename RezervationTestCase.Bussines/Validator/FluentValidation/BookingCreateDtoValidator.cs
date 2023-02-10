using FluentValidation;
using RezervationTestCase.Dtos.BookingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezervationTestCase.Bussines.Validator.FluentValidation
{
    public class BookingCreateDtoValidator : AbstractValidator<BookingCreateDto>
    {
        public BookingCreateDtoValidator()
        {
            RuleFor(x => x.CustomerName).NotNull().WithMessage("Müşteri Adını giriniz.");
            RuleFor(x => x.NumberOfVisitor).LessThanOrEqualTo(3).GreaterThan(0).WithMessage("Maksimum 3 minimum 1 kişi odada kalabilir.");
            RuleFor(x => x.ExitDate).GreaterThanOrEqualTo(x => x.EntryDate).WithMessage("Giriş Tarihi Çıkış Tarihinden Geç Olamaz.");
            RuleFor(x => x.BookingStatusId).NotNull();
        }
    }
}
