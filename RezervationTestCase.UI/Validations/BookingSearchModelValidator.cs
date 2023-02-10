using FluentValidation;
using RezervationTestCase.UI.Models;

namespace RezervationTestCase.UI.Validations
{
    public class BookingSearchModelValidator : AbstractValidator<BookingSearchModel>
    {
        public BookingSearchModelValidator()
        {
            RuleFor(x => x.NumberOfVisitor).LessThanOrEqualTo(3).GreaterThan(0);
            RuleFor(x => x.EntryDate).LessThanOrEqualTo(x => x.ExitDate);
        }
    }
}
