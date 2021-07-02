using System;
using System.Collections.Generic;
using System.Text;

namespace QLSVOFFICIAL.Utilities.Exceptions
{
    public class QLSVOFFICIALException : Exception
    {
        public QLSVOFFICIALException()
        {
        }

        public QLSVOFFICIALException(string message)
            : base(message)
        {
        }

        public QLSVOFFICIALException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
