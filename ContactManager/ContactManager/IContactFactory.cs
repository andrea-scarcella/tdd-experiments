﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactManager
{
    public interface IContactFactory
    {
        Contact createContact();
    }
}
