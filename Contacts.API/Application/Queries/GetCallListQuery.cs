using Contacts.API.Application.Models;
using MediatR;
using System.Collections.Generic;

namespace Contacts.API.Application.Queries
{
    public class GetCallListQuery : IRequest<List<HomeContactModel>>
    { }
}
