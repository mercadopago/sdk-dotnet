using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace px_dotnet.Exceptions
{
    public class MPConfException : MPException
    {
        public MPConfException(string message) : base(message) {
        }
    }
}
