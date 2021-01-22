using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSkills.Api.Controllers.Persons
{
    public class RemoveSkillsFromPersonRequest
    {
        public Guid Id { get; set; }
        public Guid SkillId { get; set; }
    }
}
