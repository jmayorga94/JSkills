using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSkills.Api.Controllers.Persons
{
    public class AddSkillsToPersonRequest
    {
        public Guid Id { get; set; }
        public List<Guid> SkillsId { get; set; }

    }
}
