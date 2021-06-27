using Contacts.API.Application.Models;
using Contacts.Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Contacts.API.Application.Queries
{
    public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, List<ContactModel>>
    {
        private readonly IContactRepository _contactRepository;

        public GetContactsQueryHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<List<ContactModel>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await this._contactRepository.GetContactsAsync();
            return contacts.Select(c => new ContactModel
            {
                Id = c.Id,
                Email = c.Email,
                Name = new NameModel
                {
                    First = c.Name?.First,
                    Middle = c.Name?.Middle,
                    Last = c.Name?.Last
                },
                Address = new AddressModel
                {
                    City = c.Address?.City,
                    State = c.Address?.State,
                    Street = c.Address?.Street,
                    Zip = c.Address?.Zip
                },
                Phone = c.Phone.Select(p => new PhoneModel
                {
                    Number = p.Number,
                    Type = p.Type
                }).ToList()
            }).ToList();
        }
    }
}
