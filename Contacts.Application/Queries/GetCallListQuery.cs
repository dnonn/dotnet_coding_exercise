using Contacts.Application.Models;
using MediatR;
using System.Collections.Generic;

namespace Contacts.Application.Queries
{
    public class GetCallListQuery : IRequest<List<HomeContactModel>>
    { }
}
