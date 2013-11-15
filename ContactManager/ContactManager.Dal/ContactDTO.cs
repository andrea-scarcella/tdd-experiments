using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ContactManager.Dal
{
    [DataContract]
    public class ContactDTO
    {
        public ContactDTO()
        {

        }
        public ContactDTO(Contact c)
        {
            Id = c.Id;
            EMail = c.EMail;
            mobile = c.mobile;
        }
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string EMail { get; set; }
        [DataMember]
        public string mobile { get; set; }

    }
}
