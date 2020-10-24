using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NGRPrisonAPI.Dto;
using NGRPrisonAPI.Models;
using NGRPrisonAPI.Services;

namespace NGRPrisonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrisonsController : ControllerBase
    {
        private readonly IPrisonRepository _prisonRepo;
        private readonly IMapper _mapper;
        public PrisonsController(IPrisonRepository prisonRepo, IMapper mapper)
        {
            _prisonRepo = prisonRepo;
            _mapper = mapper;
        }

        [HttpGet("prisonbystate/{stateId}")]
        public async Task<ActionResult<PrisonDto[]>> GetPrisonByState(int stateId, bool includeInmates = false)
        {
            var results = await _prisonRepo.GetPrisonByState(stateId, includeInmates);
            var mappedEntities = _mapper.Map<PrisonDto[]>(results);
            return Ok(mappedEntities);
        }

        [HttpGet("{prisonId}")]
        public async Task<ActionResult<PrisonDto>> GetPrison(int prisonId, bool includeInmates = false)
        {
            var results = await _prisonRepo.GetPrison(prisonId, includeInmates);
            var mappedEntities = _mapper.Map<PrisonDto>(results);
            return Ok(mappedEntities);
        }

        [HttpGet("allprison")]
        public async Task<ActionResult<PrisonDto[]>> GetPrisons(bool includeInmates = false)
        {
            var results = await _prisonRepo.GetPrisons(includeInmates);
            var mappedEntities = _mapper.Map<PrisonDto[]>(results);
            return Ok(mappedEntities);
        }
    }
}
