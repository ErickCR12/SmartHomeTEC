using Microsoft.AspNetCore.Mvc;
using API_Service.Data;
using AutoMapper;
using API_Service.DTOs;
using System.Collections.Generic;

namespace API_Service.Controllers
{

    //This is an API Controller for the Chef entity type. This Controller allows a GET request to obtain all the Chefs in the database.
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly ISmartHomeRepo _repository;
        private readonly IMapper _mapper;

        public DevicesController (ISmartHomeRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        //GET api/chef
        //This request returns a list of Chef entities in a JSON format representing the chef database.
        [HttpGet]
        public ActionResult <DeviceDto> GetAllDevices()
        {
            var devicesItem = _repository.GetAllDevices();
            return Ok(_mapper.Map<IEnumerable<DeviceDto>>(devicesItem));
        }
    }
}