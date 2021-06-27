using Contacts.API.Application.Exceptions;
using Contacts.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Contacts.API.Application.Commands
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
    {
        private readonly IContactRepository _contactRepository;

        public DeleteContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetContactAsync(request.Id);
            if (contact == null)
            {
                throw new NotFoundException("contact", request.Id);
            }

            await _contactRepository.DeleteContactAsync(contact);
            return Unit.Value;
        }
    }
}
