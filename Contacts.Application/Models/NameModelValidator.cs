using FluentValidation;

namespace Contacts.Application.Models
{
    public class NameModelValidator : AbstractValidator<NameModel>
    {
        public NameModelValidator()
        {
            RuleFor(c => c.First)
                .NotEmpty().WithMessage("First name is required.");

            RuleFor(c => c.Middle)
                .NotEmpty().WithMessage("Middle name is required.");

            RuleFor(c => c.Last)
                .NotEmpty().WithMessage("Last name is required.");
        }
    }
}
