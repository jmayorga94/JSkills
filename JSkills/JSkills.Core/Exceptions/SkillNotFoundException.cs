using System;
using System.Runtime.Serialization;

namespace JSkills.Core.Services
{
  
    public class SkillNotFoundException : Exception
    {
        public SkillNotFoundException() : base("Skill not found")
        {
        }

        public SkillNotFoundException(string message) : base(message)
        {
        }

        public SkillNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SkillNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}