using FluentValidation;

namespace Contacts.Application.Models
{
    public class AddressModelValidator : AbstractValidator<AddressModel>
    {
        public AddressModelValidator()
        {
            RuleFor(c => c.City)
                .NotEmpty().WithMessage("City is required.");

            RuleFor(c => c.State)
                .NotEmpty().WithMessage("State is required.");

            RuleFor(c => c.Street)
                .NotEmpty().WithMessage("Street is required.");

            RuleFor(c => c.Zip)
                .NotEmpty().WithMessage("Zip is required.");
        }
    }
}
