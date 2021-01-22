using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JSkills.Core.Models;
using JSkills.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JSkills.Api.Controllers.Skills
{
    [ApiVersion("1")]
    [Route("api/v{apiVersion:apiVersion}/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _service;
        private readonly IMapper _mapper;

        public SkillsController(ISkillService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<List<SkillDto>> GetAll()
        {
            try
            {
                var skills = _service.GetAll().ToList();

                List<SkillDto> skillsDto = _mapper.Map<List<SkillDto>>(skills);

                return Ok(skillsDto);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
         

           
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var skillOnDb = _service.GetById(id);

                var dto = _mapper.Map<SkillDto>(skillOnDb);

                return Ok(dto);
            }
            catch (SkillNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
           
        }

        [HttpPost]
        public IActionResult Create(CreateSkillRequest request)
        {
            try
            {
                var skillToCreate = _service.Create(request.Name);

                var dto = _mapper.Map<SkillDto>(skillToCreate);

                return CreatedAtAction(nameof(GetById), new { id = skillToCreate.Id }, dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          

           
        }


    }
}