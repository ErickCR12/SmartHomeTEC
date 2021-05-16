using Microsoft.AspNetCore.Mvc;
using API_Service.Data;
using AutoMapper;
using API_Service.DTOs;
using System.Collections.Generic;
using API_Service.Models;

namespace API_Service.Controllers
{

    //This is an API Controller for the DeviceTypes entity type.
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

        //GET api/devicetypes
        //This request returns a list of DeviceTypes entities in a JSON format representing the device_types database.
        [HttpGet]
        public ActionResult <IEnumerable<DeviceTypeDto>> GetAllDeviceTypes()
        {
            var deviceTypesItem = _repository.GetAllDeviceTypes();
            return Ok(_mapper.Map<IEnumerable<DeviceTypeDto>>(deviceTypesItem));
        }

        //GET api/devicetypes/{name}
        //This request returns a single DeviceType entity in a JSON format. This entity has the same name
        //as the received in the request header.
        [HttpGet("{name}", Name = "GetDeviceByName")]
        public ActionResult <DeviceTypeDto> GetDeviceTypeByName(string name)
        {
            var deviceTypeModel = _repository.GetDeviceType(name);
            if(deviceTypeModel != null){
                return Ok(_mapper.Map<DeviceTypeDto>(deviceTypeModel));
            }
            return NotFound();
        }

        //POST api/devicetypes
        //This request receives all the needed info to create a new DeviceType in the device_types database.
        [HttpPost]
        public ActionResult <DeviceTypeDto> CreateDeviceType(DeviceTypeDto deviceTypeDto)
        {
            var deviceTypeModel = _mapper.Map<DeviceType>(deviceTypeDto);
            _repository.AddDeviceType(deviceTypeModel);

            var newDeviceTypeDto = _mapper.Map<DeviceTypeDto>(deviceTypeModel);

            return CreatedAtRoute(nameof(GetDeviceTypeByName), new {name = newDeviceTypeDto.name}, 
                                newDeviceTypeDto);
        }

        
        //PUT api/devicetypes/{name}
        //This request receives a JSON representing DeviceType Entity to be updated. This JSON is mapped to a DeviceType Data Model 
        //and with the name received in the header of the request, the matching entity will be replaced with the new info.
        [HttpPut("{name}")]
        public ActionResult UpdateDeviceType(string name, DeviceTypeDto deviceTypeDto)
        {
            var deviceTypeFromRepo = _repository.GetDeviceType(name);
            deviceTypeDto.name = deviceTypeFromRepo.name;
            if(deviceTypeFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(deviceTypeDto, deviceTypeFromRepo);
            _repository.UpdateDeviceType(deviceTypeFromRepo);

            return NoContent();
        }

        //DELETE api/devicetypes/{id}
        //This request deletes the DeviceType entity with the name received in the request header.
        [HttpDelete("{name}")]
        public ActionResult DeleteDeviceType(string name)
        {
            var deviceTypeFromRepo = _repository.GetDeviceType(name);
            if(deviceTypeFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteDeviceType(deviceTypeFromRepo);
            return NoContent();
        }
    }
}