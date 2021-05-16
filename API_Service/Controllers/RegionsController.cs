using Microsoft.AspNetCore.Mvc;
using API_Service.Data;
using AutoMapper;
using API_Service.DTOs;
using System.Collections.Generic;
using API_Service.Models;
using System;

namespace API_Service.Controllers
{

    //This is an API Controller for the Order entity type. 
    //This Controller allows a  a POST request to create a new Order.
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly ISmartHomeRepo _repository;
        private readonly IMapper _mapper;

        public RegionsController (ISmartHomeRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        //GET api/regions/continents
        //This request returns all the registered contienents in the regions database.
        [HttpGet("continents")]
        public ActionResult <IEnumerable<RegionDto>> GetAllContinents()
        {
            var regionsItem = _repository.GetAllContinents();
            return Ok(_mapper.Map<IEnumerable<RegionDto>>(regionsItem));
        }

        //GET api/regions/countries/{continent}
        //This request returns all the countries of the specified continent in the regions database.
        [HttpGet("countries/{continent}")]
        public ActionResult <IEnumerable<RegionDto>> GetCountriesByContinent(string continent)
        {
            var regionsItem = _repository.GetCountriesByContinent(continent);
            return Ok(_mapper.Map<IEnumerable<RegionDto>>(regionsItem));
        }

    }
}