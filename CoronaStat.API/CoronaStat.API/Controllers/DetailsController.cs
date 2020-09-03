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
    [Route("api/Details")]
    public class DetailsController : ControllerBase
    {
        private IAppRepository _appRepository;
        private IMapper _mapper;

        public DetailsController(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }

        public ActionResult GetDetail()
        {
            var detail = _appRepository.GetDetail();
            var detailToReturn = _mapper.Map<List<WorldForDto>>(detail);
            return Ok(detailToReturn);
        }
        // GET api/details/5
        [HttpGet("{id}")]
        public ActionResult GetDetails(int id)
        {
            var detail = _appRepository.GetDetails(id);
            var detailToReturn = _mapper.Map<List<WorldForDto>>(detail);
            return Ok(detailToReturn);
        
        }
        [HttpPost]
        [Route("add")]
        //public ActionResult Add([FromBody]Country country)
        public ActionResult Add([FromForm]WorldForDto countryForListDto, Value value)
        {
            /* var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

             if (currentUserId ==null)
             {
                 return Unauthorized();
             }*/

            _appRepository.Add(value);
            _appRepository.SaveAll();
            return Ok(value);

        }

    }
}