using Contacts.API.Application.Models;
using MediatR;
using System;

namespace Contacts.API.Application.Queries
{
    public class GetContactQuery : IRequest<ContactModel>
    {
        public int Id { get; }

        public GetContactQuery(int id)
        {
            Id = id;
        }
    }
}
