using JSkills.Core.Models;
using JSkills.Core.Repositories;
using JSkills.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSkills.EntityFramework.Repositories
{
    public class SkillRepositoryImpl : ISkillRepository
    {
        private readonly JSkillsDbContext _context;

        public SkillRepositoryImpl(JSkillsDbContext context)
        {
            _context = context;
        }
        public void DisableSkill(Skill skill)
        {
            Edit(skill);
        }

        public bool DoesExists(Guid id)
        {
            return _context.Skills.Where(x => x.Id == id && x.IsActive == true).Count() > 1;
        }

        public void Edit(Skill skill)
        {
             _context.Skills.Update(skill);
        }

        public IQueryable<Skill> GetAll()
        {
            return _context.Skills;
        }

        public Skill GetById(Guid id)
        {
            return _context.Skills.Where(x => x.Id == id && x.IsActive == true).FirstOrDefault();
        }

        public Skill Save(Skill skill)
        {
            _context.Skills.Add(skill);
            _context.SaveChanges();

            return skill;
        }

    }
}
