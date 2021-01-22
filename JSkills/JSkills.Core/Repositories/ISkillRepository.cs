using JSkills.Core.Models;
using System;
using System.Linq;

namespace JSkills.Core.Repositories
{
    public interface ISkillRepository
    {
        Skill GetById(Guid id);
        Skill Save(Skill skill);
        void Edit(Skill skill);
        void DisableSkill(Skill skill);
        bool DoesExists(Guid id);
        IQueryable<Skill> GetAll();

    }
}
