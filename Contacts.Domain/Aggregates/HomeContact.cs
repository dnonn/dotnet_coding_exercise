using Contacts.Domain.Entities;

namespace Contacts.Domain.Aggregates
{
    public class HomeContact
    {
        public Name Name { get; set; }

        public string Phone { get; set; }
    }
}
