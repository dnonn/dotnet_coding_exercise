using Contacts.Application.Models;
using MediatR;

namespace Contacts.Application.Commands
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
