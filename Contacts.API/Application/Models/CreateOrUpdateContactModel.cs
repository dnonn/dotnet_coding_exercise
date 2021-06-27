using System.Collections.Generic;

namespace Contacts.API.Application.Models
{
    public class CreateOrUpdateContactModel
    {
        public NameModel Name { get; set; }

        public AddressModel Address { get; set; }

        public List<PhoneModel> Phone { get; set; } = new List<PhoneModel>();

        public string Email { get; set; }
    }
}
