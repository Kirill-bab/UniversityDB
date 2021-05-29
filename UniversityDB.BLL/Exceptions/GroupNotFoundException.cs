using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDB.BLL.Exceptions
{
    class GroupNotFoundException : Exception
    {
        public GroupNotFoundException()
        {
        }

        public GroupNotFoundException(string message) : base(message)
        { 
        }
    }
}
