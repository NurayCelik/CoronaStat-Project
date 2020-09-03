using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoronaStat.API.Data;
using CoronaStat.API.Dtos;
using CoronaStat.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoronaStat.API.Controllers
{
    [Produces("application/json")]
    [Route("api/WorldParameters")]
    public class WorldParametersController : ControllerBase
    {
        private IWorldRepository _worldRepository;
        private IMapper _mapper;

        public WorldParametersController(IWorldRepository worldRepository, IMapper mapper)
        {
            _worldRepository = worldRepository;
            _mapper = mapper;
        }

        public ActionResult GetCountry()
        {
            var worldParametre = _worldRepository.GetWorldParameter();
            var worldToReturn = _mapper.Map<List<WorldForListDto>>(worldParametre);
            return Ok(worldToReturn);
        }
        // GET api/details/5
        [HttpGet("{id}")]
        public ActionResult GetWorldParameterById(int id)
        {
            var worldParametre = _worldRepository.GetWorldParameterById(id);
            var worldToReturn = _mapper.Map<List<WorldForDto>>(worldParametre);
            return Ok(worldToReturn);

        }
        [HttpPost]
        [Route("add")]
        //public ActionResult Add([FromBody]Country country)
        public ActionResult Add([FromForm]WorldForListDto countryForListDto, WorldParameter WorldParameter)
        {
            /* var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

             if (currentUserId ==null)
             {
                 return Unauthorized();
             }*/

            _worldRepository.Add(WorldParameter);
            _worldRepository.SaveAll();
            return Ok(WorldParameter);

        }

    }
}