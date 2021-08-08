using Contacts.API.Application.Models;
using MediatR;

namespace Contacts.API.Application.Commands
{
    public class UpdateContactCommand : IRequest<int>
    {
        public int Id { get; }

        public CreateOrUpdateContactModel Contact { get; }

        public UpdateContactCommand(int id, CreateOrUpdateContactModel contact)
        {
            Id = id;
            Contact = contact;
        }
    }
}
