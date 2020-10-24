using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NGRPrisonAPI.Dto;
using NGRPrisonAPI.Services;

namespace NGRPrisonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InmatesController : ControllerBase
    {
        private readonly IPrisonRepository _prisonRepo;
        private readonly IMapper _mapper;
        public InmatesController(IPrisonRepository prisonRepo, IMapper mapper)
        {
            _prisonRepo = prisonRepo;
            _mapper = mapper;
        }

        [HttpGet("{inmateId}")]
        public async Task<ActionResult<InmateDto>> GetPrison(int inmateId)
        {
            var results = await _prisonRepo.GetInmate(inmateId);
            var mappedEntities = _mapper.Map<InmateDto>(results);
            return Ok(mappedEntities);
        }

        [HttpGet("inmatelistbyprisonid/{prisonId}")]
        public async Task<ActionResult<InmateDto[]>> GetInmatesByPrisonId(int prisonId)
        {
            var results = await _prisonRepo.GetInmatesByPrison(prisonId);
            var mappedEntities = _mapper.Map<InmateDto[]>(results);
            return Ok(mappedEntities);
        }

        [HttpGet("inmatelistbystateid/{stateId}")]
        public async Task<ActionResult<InmateDto[]>> GetInmatesByState(int stateId)
        {
            var results = await _prisonRepo.GetInmatesByState(stateId);
            var mappedEntities = _mapper.Map<InmateDto[]>(results);
            return Ok(mappedEntities);
        }
    }
}
