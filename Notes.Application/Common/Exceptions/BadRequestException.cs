using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Common.Exceptions
{
    internal class BadRequestException : Exception
    {
        public BadRequestException(string name, string message)
            : base($"Error: {message} at the {name}")
        {

        }
    }
}
