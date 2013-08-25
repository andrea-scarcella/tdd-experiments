using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ContactManager;

namespace ContactManager.Tests
{
    [TestFixture]
    public class ContactFactoryTests
    {
        [Test]
        public void canCreateContactObject()
        {
            IContactFactory cf = new ContactFactory();
            Contact c=cf.createContact();
            Assert.IsNotNull(c);
            Assert.IsInstanceOf<Contact>(c);

        }
        

    }
}
