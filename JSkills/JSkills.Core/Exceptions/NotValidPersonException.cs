using System;
using System.Collections.Generic;
using System.Text;

namespace JSkills.Core.Exceptions
{
    public class NotValidPersonException : Exception
    {
        public NotValidPersonException() : base("Person not valid")
        {
            
        }
    }
}
