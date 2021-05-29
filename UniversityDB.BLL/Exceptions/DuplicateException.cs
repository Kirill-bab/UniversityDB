using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDB.BLL.Exceptions
{
    class DuplicateException : Exception
    {
        public DuplicateException()
        {
        }
        public DuplicateException(string message) : base(message)
        {
        }
    }
}
