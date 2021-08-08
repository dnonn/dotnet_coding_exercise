using Contacts.Application.Models;
using FluentValidation;

namespace Contacts.Application.Commands
{
    public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactCommandValidator()
        {
            RuleFor(c => c.Contact)
                .NotNull().WithMessage("Contact is required")
                .SetValidator(new CreateOrUpdateContactModelValidator());
        }
    }
}
