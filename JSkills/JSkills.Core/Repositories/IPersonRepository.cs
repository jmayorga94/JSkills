using JSkills.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSkills.Core.Repositories
{
    public interface IPersonRepository
    {
        IQueryable<Person> GetAll();
        Person GetById(Guid idPerson);
        void Save(Person person);
        bool DoesExists(string documentId);
        void Update(Person person);
    }
}
