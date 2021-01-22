using JSkills.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JSkills.Core.Services
{
    public interface IPersonService
    {
        IQueryable<Person> GetAll();
        Person GetById(Guid id);

        bool DoesExists(string DocumentId);
        Person Create(string name, string email,  string position,string documentId);

        void AddSkillsToPerson(Guid id, List<Guid> skills);
        void RemoveSkillsFromPerson(Guid id, Guid skillId);
    }
}
