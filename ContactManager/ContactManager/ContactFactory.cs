using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactManager
{
    public class ContactFactory : IContactFactory
    {
        public Contact createContact()
        {
            Contact c = new Contact();
            return c;
        }
    }
}
