using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ContactManager;
using ContactManager.Dal;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace ContactManager.Tests
{
    [TestFixture]
    public class XmlContactRepositoryTests
    {
        [Test]
        public void canAddContact()
        {
            Contact c = new Contact();
            c.EMail = "a@b";
            c.mobile = "+310000";
            
            IRepository<Contact> rp = new XmlContactRepository(filename);
            rp.Add(c);
            ContactDTO actual = null;
            ContactDTO expected = new ContactDTO(c);
            //------------------------
            using (FileStream fs = File.OpenRead(filename))
            {
                XmlReaderSettings rs = new XmlReaderSettings
                {
                    ConformanceLevel = ConformanceLevel.Fragment,
                };
                XmlReader r = XmlReader.Create(fs, rs);
                while (!r.EOF)
                {
                    actual = new DataContractSerializer(typeof(ContactDTO)).ReadObject(r) as ContactDTO;
                    Assert.IsNotNull(actual);
                    Assert.AreEqual(expected.mobile, actual.mobile);
                    Assert.AreEqual(expected.EMail, actual.EMail);
                }
            }
        }
        [TestFixtureSetUp]
        public void InitializeFixture()
        {
            filename = "dc.xml";
        }
        [SetUp]
        public void RunBeforeEachTestCase()
        {
            using (FileStream f = File.Open(filename, FileMode.Open, FileAccess.Write))
            {
                f.SetLength(0);
                f.Close();
            }
        }
        public string filename { get; set; }
    }
}
