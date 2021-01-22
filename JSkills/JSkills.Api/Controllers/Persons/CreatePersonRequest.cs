using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSkills.Api.Controllers.Persons
{
    public class CreatePersonRequest
    {
        public string Name { get; set; }

        public string Email { get; set; }
        public string Position { get; set; }

        public string DocumentId { get; set; }
    }
}
