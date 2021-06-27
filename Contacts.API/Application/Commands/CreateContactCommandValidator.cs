using Contacts.API.Application.Models;
using FluentValidation;

namespace Contacts.API.Application.Commands
{
    public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidator()
        {
            RuleFor(c => c.Contact)
                .NotNull().WithMessage("Contact is required")
                .SetValidator(new CreateOrUpdateContactModelValidator());
        }
    }
}
