using JSkills.Core.Models;
using JSkills.Core.Repositories;
using JSkills.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace JSkills.EntityFramework.Repositories
{
    public class PersonRepositoryImpl : IPersonRepository
    {
        private readonly JSkillsDbContext _context;

        public PersonRepositoryImpl(JSkillsDbContext context)
        {
            _context = context;
        }

        public bool DoesExists(string documentId)
        {
            return _context.Persons.Where(x => x.DocumentId == documentId).Count()>1;
        }

        public IQueryable<Person> GetAll()
        {
            return _context.Persons.Include(x=>x.Skills);
        }

        public Person GetById(Guid id)
        {
            return _context.Persons
                .Where(x => x.Id == id)
                .Include(s=> s.Skills).FirstOrDefault();
        }

        public void Save(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        public void Update(Person person)
        {
            _context.Persons.Update(person);
            _context.SaveChanges();
        }
    }
}
