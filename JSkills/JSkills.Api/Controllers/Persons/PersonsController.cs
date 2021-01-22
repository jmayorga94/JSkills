using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using JSkills.Core.Exceptions;
using JSkills.Core.Models;
using JSkills.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace JSkills.Api.Controllers.Persons
{
    [Route("api/v{apiVersion:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _service;
        private readonly IMapper _mapper;
        public PersonsController(IPersonService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IList<PersonDto>> GetAll()
        {
            var persons = _service.GetAll().ToList();

            List<PersonDto> personList = _mapper.Map<List<PersonDto>>(persons);

            return Ok(personList);
        }

        [HttpGet("{id}")]
        public ActionResult<PersonDto> GetById(Guid id)
        {
            try
            {
                var person = _service.GetById(id);
                var personDto = _mapper.Map<PersonDto>(person);

                return Ok(personDto);
            }
            catch (PersonNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost()]
        public IActionResult Save(CreatePersonRequest dto)
        {
            try
            {
                var newPerson = _service.Create(dto.Name, dto.Email, dto.Position, dto.DocumentId);

                var personDto = _mapper.Map<PersonDto>(newPerson);

                return CreatedAtAction(nameof(GetById), new { id = newPerson.Id }, personDto);
            }
            catch (NotValidPersonException ex)
            {

                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("{id}/skills")]
      public IActionResult AddSkillsToPerson(AddSkillsToPersonRequest request)
        {
            try
            {
                _service.AddSkillsToPerson(request.Id, request.SkillsId);

                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}/skills/{skillId}")]
        public IActionResult RemoveSkillsFromPerson(Guid id, Guid skillId)
        {
            try
            {
                _service.RemoveSkillsFromPerson(id, skillId);

                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

    }
}