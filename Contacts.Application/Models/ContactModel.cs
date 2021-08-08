using System;
using System.Collections.Generic;

namespace Contacts.API.Application.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        
        public NameModel Name { get; set; }

        public AddressModel Address { get; set; }

        public List<PhoneModel> Phone { get; set; }

        public string Email { get; set; }
    }
}
