using JSkills.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSkills.Core.Services
{
    public interface ISkillService
    {
        IQueryable<Skill> GetAll();
        Skill GetById(Guid id);
        bool DoesExists(Guid id);
        Skill Create(string name);

        void Edit(Guid id, Skill skill);
        void DisableSkill(Guid id);
    }
}
