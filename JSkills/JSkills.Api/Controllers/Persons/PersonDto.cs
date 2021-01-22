using JSkills.Api.Controllers.Skills;
using JSkills.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSkills.Api.Controllers.Persons
{
    public class PersonDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string DocumentId { get; set; }

        public string Position { get; set; }
        public List<SkillDto> Skills { get; set; }
    }
}
