using Contacts.API.Application.Models;
using MediatR;
using System.Collections.Generic;

namespace Contacts.API.Application.Queries
{
    public class GetContactsQuery : IRequest<List<ContactModel>>
    { }
}
