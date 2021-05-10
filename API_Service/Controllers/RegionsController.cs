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

        //GET api/clients
        //This request receives all the needed info to create a new Client in the clients database.
        [HttpGet("continents")]
        public ActionResult <IEnumerable<RegionDto>> GetAllContinents()
        {
            var regionsItem = _repository.GetAllContinents();
            return Ok(_mapper.Map<IEnumerable<RegionDto>>(regionsItem));
        }

        [HttpGet("countries/{continent}")]
        public ActionResult <IEnumerable<RegionDto>> GetCountriesByContinent(string continent)
        {
            var regionsItem = _repository.GetCountriesByContinent(continent);
            return Ok(_mapper.Map<IEnumerable<RegionDto>>(regionsItem));
        }

    }
}