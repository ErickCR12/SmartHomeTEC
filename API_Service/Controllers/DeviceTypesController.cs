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
    public class DeviceTypesController : ControllerBase
    {
        private readonly ISmartHomeRepo _repository;
        private readonly IMapper _mapper;

        public DeviceTypesController (ISmartHomeRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        //GET api/chef
        //This request returns a list of Chef entities in a JSON format representing the chef database.
        [HttpGet]
        public ActionResult <DeviceTypeDto> GetAllDeviceTypes()
        {
            var deviceTypesItem = _repository.GetAllDeviceTypes();
            return Ok(_mapper.Map<IEnumerable<DeviceTypeDto>>(deviceTypesItem));
        }
    }
}