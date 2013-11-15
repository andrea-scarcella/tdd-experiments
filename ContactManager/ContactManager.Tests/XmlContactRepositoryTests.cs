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
        private Contact[] _contacts;
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
            var repoContents = repoToList();
            actual = repoContents.Where(el => c.Id.Equals(el.Id)).FirstOrDefault();
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.mobile, actual.mobile);
            Assert.AreEqual(expected.EMail, actual.EMail);
        }

        private List<ContactDTO> repoToList()
        {
            List<ContactDTO> l = new List<ContactDTO>();
            ContactDTO actual = null;
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
                    l.Add(actual);
                }
            }
            return l;
        }
        [Test]
        public void canUpdateContact()
        {
            Contact c = new Contact();
            c.EMail = "a@b";
            c.mobile = "+310000";

            IRepository<Contact> rp = new XmlContactRepository(filename);
            rp.Add(c);
            ContactDTO actual = null;
            ContactDTO expected = new ContactDTO(c);
            //------------------------
            var repoContents = repoToList();
            actual = repoContents.LastOrDefault();
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.mobile, actual.mobile);
            Assert.AreEqual(expected.EMail, actual.EMail);

        }
        [TestFixtureSetUp]
        public void InitializeFixture()
        {
            filename = "dc.xml";
            _contacts = new[] { new Contact { EMail="a@b", mobile="+310"}, 
                new Contact { EMail="c@d", mobile="+440"},
                new Contact { EMail="e@f", mobile="+450"},
                new Contact { EMail="g@h", mobile="+460"}
            };
        }
        [SetUp]
        public void RunBeforeEachTestCase()
        {
            using (FileStream f = File.Open(filename, FileMode.Open, FileAccess.Write))
            {
                f.SetLength(0);
                f.Close();
            }

            using (FileStream writer = new FileStream(filename, FileMode.Append, FileAccess.Write))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(ContactDTO));
                ContactDTO cd = null;
                foreach (var item in _contacts)
                {
                    cd = new ContactDTO(item);
                    ser.WriteObject(writer, cd);
                }
                writer.Close();
            }

        }
        public string filename { get; set; }
    }
}
