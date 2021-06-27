using Contacts.Domain.Aggregates;
using Contacts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Domain.Repositories
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetContactsAsync();

        Task<List<HomeContact>> GetCallListAsync();

        Task<Contact> GetContactAsync(int id);

        Task AddContactAsync(Contact contact);

        Task UpdateContactAsync(Contact contact);

        Task DeleteContactAsync(Contact contact);
    }
}
