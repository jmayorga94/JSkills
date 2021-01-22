using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSkills.Api.Controllers.Skills
{
    public class SkillDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
