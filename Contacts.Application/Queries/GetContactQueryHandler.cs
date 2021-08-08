using Contacts.API.Application.Exceptions;
using Contacts.API.Application.Models;
using Contacts.Domain.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Contacts.API.Application.Queries
{
    public class GetContactQueryHandler : IRequestHandler<GetContactQuery, ContactModel>
    {
        private readonly IContactRepository _contactRepository;

        public GetContactQueryHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<ContactModel> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var contact = await this._contactRepository.GetContactAsync(request.Id);
            if (contact == null)
            {
                throw new NotFoundException("contact", request.Id);
            }

            return new ContactModel()
            {
                Id = contact.Id,
                Email = contact.Email,
                Name = new NameModel
                {
                    First = contact.Name?.First,
                    Middle = contact.Name?.Middle,
                    Last = contact.Name?.Last
                },
                Address = new AddressModel
                {
                    City = contact.Address?.City,
                    State = contact.Address?.State,
                    Street = contact.Address?.Street,
                    Zip = contact.Address?.Zip
                },
                Phone = contact.Phone.Select(p => new PhoneModel
                {
                    Number = p.Number,
                    Type = p.Type
                }).ToList()
            };
        }
    }
}
