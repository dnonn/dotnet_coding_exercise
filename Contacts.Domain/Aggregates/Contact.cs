using System;
using System.Collections.Generic;

namespace Contacts.Domain.Entities
{
    public class Contact : Entity
    {
        public Name Name { get; set; }

        public Address Address { get; set; }

        public List<Phone> Phone { get; set; }

        public string Email { get; set; }
    }
}