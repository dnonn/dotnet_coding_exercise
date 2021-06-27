using Contacts.API.Application.Models;
using MediatR;

namespace Contacts.API.Application.Commands
{
    public class CreateContactCommand : IRequest<int>
    {
        public CreateOrUpdateContactModel Contact { get; }

        public CreateContactCommand(CreateOrUpdateContactModel contact)
        {
            Contact = contact;
        }
    }
}
