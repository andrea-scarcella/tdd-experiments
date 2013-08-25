using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Dal
{
    public class XmlContactRepository : IRepository<Contact>
    {
        List<ContactDTO> _cache = new List<ContactDTO>();   
        public void Add(Contact c)
        {
            ContactDTO cd = new ContactDTO(c);
            _cache.Add(cd);
            using (FileStream writer = new FileStream(_filename, FileMode.Append, FileAccess.Write))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(ContactDTO));
                ser.WriteObject(writer, cd);
                writer.Close();
            }
     
        }

        private string _filename;

        public XmlContactRepository(string filename)
        {
            // TODO: Complete member initialization
            this._filename = filename;
        }

    }
}
