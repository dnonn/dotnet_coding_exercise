using Contacts.Domain.Entities;
using Contacts.Domain.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Contacts.API.Application.Commands
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, int>
    {
        private readonly IContactRepository _contactRepository;

        public CreateContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Contact
            {
                Email = request.Contact.Email,
                Address = new Address
                {
                    Street = request.Contact.Address.Street,
                    City = request.Contact.Address.City,
                    State = request.Contact.Address.State,
                    Zip = request.Contact.Address.Zip
                },
                Name = new Name
                {
                    First = request.Contact.Name.First,
                    Middle = request.Contact.Name.Middle,
                    Last = request.Contact.Name.Last
                },
                Phone = request.Contact.Phone.Select(p => new Phone
                {
                    Number = p.Number,
                    Type = p.Type
                }).ToList()
            };

            await _contactRepository.AddContactAsync(contact);
            return contact.Id;
        }
    }
}
