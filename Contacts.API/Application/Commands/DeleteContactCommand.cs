using MediatR;
using System;

namespace Contacts.API.Application.Commands
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
