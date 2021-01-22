using System;
using System.Collections;
using System.Collections.Generic;

namespace JSkills.Core.Models
{
    public class Skill
    {
        public Skill(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            IsActive = true;
            Persons = new List<Person>();

        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Person> Persons { get; set; }



    }
}