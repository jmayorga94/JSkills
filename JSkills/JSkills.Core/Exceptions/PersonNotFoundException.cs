using System;
using System.Collections.Generic;
using System.Text;

namespace JSkills.Core.Exceptions
{
    public class PersonNotFoundException : Exception
    {
        public PersonNotFoundException() :base("Person not found")
        {

        }
    }
}
