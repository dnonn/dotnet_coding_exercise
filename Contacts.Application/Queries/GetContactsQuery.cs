using Contacts.Application.Models;
using MediatR;
using System.Collections.Generic;

namespace Contacts.Application.Queries
{
    public class GetContactsQuery : IRequest<List<ContactModel>>
    { }
}
