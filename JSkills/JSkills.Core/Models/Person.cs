using System;
using System.Collections.Generic;
using System.Text;

namespace JSkills.Core.Models
{
    public class Person
    {
        public Person(string name,string email, string position,string documentId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            DocumentId = documentId;
            Position = position;
            Skills = new List<Skill>();
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string DocumentId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }
}
