using MediatR;

namespace Contacts.Application.Commands
{
    public class DeleteContactCommand : IRequest
    {
        public int Id { get; }

        public DeleteContactCommand(int id)
        {
            Id = id;
        }
    }
}
