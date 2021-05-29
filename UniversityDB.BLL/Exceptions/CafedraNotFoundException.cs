using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDB.BLL.Exceptions
{
    class CafedraNotFoundException : Exception
    {
        public CafedraNotFoundException()
        {
        }
        public CafedraNotFoundException(string message) : base(message)
        {
        }
    }
}
