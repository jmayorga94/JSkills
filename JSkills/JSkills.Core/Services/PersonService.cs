using JSkills.Core.Exceptions;
using JSkills.Core.Models;
using JSkills.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JSkills.Core.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly ISkillRepository _skillRepository;
        public PersonService(IPersonRepository personRepository, ISkillRepository skillRepository)
        {
            _personRepository = personRepository;
            _skillRepository = skillRepository;
        }

        public bool DoesExists(string documentId)
        {
            return _personRepository.DoesExists(documentId);
        }

        public IQueryable<Person> GetAll()
        {
           return _personRepository.GetAll();
        }

        public Person GetById(Guid id)
        {

            var person =  _personRepository.GetById(id);

            if (person == null)
            {
                throw new PersonNotFoundException();
            }

            return person;
        }

        public Person Create(string name, string email, string position, string documentId)
        {
            try
            {
                Person person = new Person(name, email, position, documentId);
               
                _personRepository.Save(person);

                return person;

            }
            catch (NotValidPersonException ex)
            {

                throw ex;
            }
           
        }

        public void AddSkillsToPerson(Guid id, List<Guid> skillIds)
        {
            var personOnDb = GetById(id);

            foreach (var skillId in skillIds)
            {
                var skillToAdd = _skillRepository.GetById(skillId);

                personOnDb.Skills.Add(skillToAdd);
            }

            _personRepository.Update(personOnDb);
        }

        public void RemoveSkillsFromPerson(Guid id, Guid skillId)
        {
            var personOnDb = GetById(id);

            var skillToRemove = personOnDb.Skills.Where(x => x.Id == skillId).FirstOrDefault();

            personOnDb.Skills.Remove(skillToRemove);

            _personRepository.Update(personOnDb);
        }
    }
}
