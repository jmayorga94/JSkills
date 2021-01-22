using JSkills.Core.Models;
using JSkills.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSkills.Core.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _repository;

        public SkillService(ISkillRepository repository)
        {
            _repository = repository;
        }

        public void DisableSkill(Guid id)
        {
            var skill = GetById(id);

            skill.IsActive = false;

            _repository.DisableSkill(skill);
        }

        public bool DoesExists(Guid id)
        {
            return _repository.DoesExists(id);
        }

        public void Edit(Guid id, Skill skill)
        {
            var skillOnDb = GetById(id);

            skillOnDb.Name = skill.Name;

            _repository.Edit(skillOnDb);
        }

        public IQueryable<Skill> GetAll()
        {
            return _repository.GetAll();
        }

        public Skill GetById(Guid id)
        {
            var skill =  _repository.GetById(id);

            if (skill == null)
            {
                throw new SkillNotFoundException();
            }

            return skill;
        }

        public Skill Create(string name)
        {
            Skill skill = new Skill(name);

            _repository.Save(skill);

            return skill;
        }
    }
}
