using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.API.Application.Models
{
    public class CreateOrUpdateContactModelValidator : AbstractValidator<CreateOrUpdateContactModel>
    {
        public CreateOrUpdateContactModelValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email is required.");

            RuleFor(c => c.Address)
                .NotNull().WithMessage("Address is required.")
                .SetValidator(new AddressModelValidator());

            RuleFor(c => c.Name)
                .NotNull().WithMessage("Name is required.")
                .SetValidator(new NameModelValidator());

            RuleFor(c => c.Phone)
                .NotNull().WithMessage("Phone is required.");

            RuleForEach(c => c.Phone)
                .NotNull().WithMessage("Phone is required")
                .SetValidator(new PhoneModelValidator());
        }
    }
}
