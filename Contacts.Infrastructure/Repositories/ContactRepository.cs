using Contacts.Domain.Aggregates;
using Contacts.Domain.Constants;
using Contacts.Domain.Entities;
using Contacts.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactContext _context;

        public ContactRepository(ContactContext context)
        {
            _context = context;
        }

        public async Task AddContactAsync(Contact contact)
        {
            await this._context.AddAsync(contact);
            await this._context.SaveChangesAsync();
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            this._context.Contacts.Update(contact);
            await this._context.SaveChangesAsync();
        }

        public async Task DeleteContactAsync(Contact contact)
        {
            this._context.Remove(contact);
            await this._context.SaveChangesAsync();
        }

        public async Task<List<HomeContact>> GetCallListAsync()
        {
            var query = from contact in this._context.Contacts
                        where contact.Phone.Any(p => p.Type == PhoneType.Home)
                        select new HomeContact
                        {
                            Name = contact.Name,
                            Phone = contact.Phone.FirstOrDefault(p => p.Type == PhoneType.Home).Number
                        };

            return await query
                .OrderBy(c => c.Name.Last)
                .ThenBy(c => c.Name.First)
                .ToListAsync();
        }

        public async Task<Contact> GetContactAsync(int id)
        {
            return await this._context.Contacts
                .Include(c => c.Address)
                .Include(c => c.Name)
                .Include(c => c.Phone)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Contact>> GetContactsAsync()
        {
            return await this._context.Contacts
                .Include(c => c.Address)
                .Include(c => c.Name)
                .Include(c => c.Phone)
                .ToListAsync();
        }
    }
}
