using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using CoronaStat.API.Data;
using CoronaStat.API.Dtos;
using CoronaStat.API.Models;
using Microsoft.AspNetCore.Mvc;


namespace CoronaStat.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Countries")]
    public class CountriesController : ControllerBase
    {
     
        private IAppRepository _appRepository;
        private IMapper _mapper;

        public CountriesController(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }

        public ActionResult GetCountry()
        {
            var country = _appRepository.GetCountries();
            var countryToReturn = _mapper.Map<List<CountryForListDto>>(country);
            return Ok(countryToReturn);
        }

        [HttpPost]
        [Route("add")]
        //public ActionResult Add([FromBody]Country country)
        public ActionResult Add([FromForm]CountryForListDto countryForListDto, Country country)
        {
           /* var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (currentUserId ==null)
            {
                return Unauthorized();
            }*/

            _appRepository.Add(country);
            _appRepository.SaveAll();
            return Ok(country);

        }
  



    }

}