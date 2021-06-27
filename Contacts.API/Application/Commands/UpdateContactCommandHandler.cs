using Contacts.API.Application.Exceptions;
using Contacts.Domain.Entities;
using Contacts.Domain.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Contacts.API.Application.Commands
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, int>
    {
        private readonly IContactRepository _contactRepository;

        public UpdateContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<int> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetContactAsync(request.Id);
            if (contact == null)
            {
                throw new NotFoundException("contact", request.Id);
            }

            contact.Email = request.Contact.Email;

            contact.Name.First = request.Contact.Name.First;
            contact.Name.Middle = request.Contact.Name.Middle;
            contact.Name.Last = request.Contact.Name.Last;

            contact.Address.State = request.Contact.Address.State;
            contact.Address.City = request.Contact.Address.City;
            contact.Address.Zip = request.Contact.Address.Zip;
            contact.Address.Street = request.Contact.Address.Street;
            
            contact.Phone = request.Contact.Phone.Select(p => new Phone
            {
                Number = p.Number,
                Type = p.Type
            }).ToList();

            await _contactRepository.UpdateContactAsync(contact);
            return contact.Id;
        }
    }
}
