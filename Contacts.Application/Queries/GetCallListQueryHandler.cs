using Contacts.Application.Models;
using Contacts.Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Contacts.Application.Queries
{
    public class GetCallListQueryHandler : IRequestHandler<GetCallListQuery, List<HomeContactModel>>
    {
        private readonly IContactRepository _contactRepository;

        public GetCallListQueryHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<List<HomeContactModel>> Handle(GetCallListQuery request, CancellationToken cancellationToken)
        {
            var callList = await _contactRepository.GetCallListAsync();
            return callList.Select(c => new HomeContactModel
            {
                Name = new NameModel
                {
                    First = c.Name.First,
                    Middle = c.Name.Middle,
                    Last = c.Name.Last
                },
                Phone = c.Phone
            }).ToList();
        }
    }
}
