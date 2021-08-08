using FluentValidation;

namespace Contacts.API.Application.Models
{
    public class PhoneModelValidator : AbstractValidator<PhoneModel>
    {
        public PhoneModelValidator()
        {
            RuleFor(c => c.Number)
                .NotEmpty().WithMessage("Phone number is required.");

            RuleFor(c => c.Type)
                .Must(BeValidPhoneType).WithMessage("Phone type must have a value of \"home\", \"work\", or \"mobile\"");
        }

        private bool BeValidPhoneType(string type)
        {
            return type == "home"
                || type == "work"
                || type == "mobile";
        }
    }
}
