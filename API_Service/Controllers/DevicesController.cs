using Microsoft.AspNetCore.Mvc;
using API_Service.Data;
using AutoMapper;
using API_Service.DTOs;
using System.Collections.Generic;
using API_Service.Models;
using System;

namespace API_Service.Controllers
{

    //This is an API Controller for the Device entity type. 
    //This Controller allows a GET request to obtain all the Devices in the database.
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

        //GET api/devices
        //This request returns a list of Device entities in a JSON format representing the chef database.
        [HttpGet]
        public ActionResult<IEnumerable<DeviceDto>> GetAllDevices()
        {
            var devicesItem = _repository.GetAllDevices();
            return Ok(_mapper.Map<IEnumerable<DeviceDto>>(devicesItem));
        }

        //GET api/devices/byclient/{client_email}
        //This request returns a list of Device entities in a JSON format representing the chef database.
        [HttpGet("byclient/{client_email}")]
        public ActionResult<IEnumerable<DeviceDto>> GetAllDevicesByClient(string client_email)
        {
            var devicesItem = _repository.GetAllDevicesByClient(client_email);
            return Ok(_mapper.Map<IEnumerable<DeviceDto>>(devicesItem));
        }

        //GET api/devices/{serial_number}
        //This request returns a single Device entity in a JSON format. This entity has the same serial number
        //as the received in the request header.
        [HttpGet("{serial_number}", Name = "GetDeviceBySerialNumber")]
        public ActionResult <DeviceDto> GetDeviceBySerialNumber(int serial_number)
        {
            var deviceModel = _repository.GetDevice(serial_number);
            if(deviceModel != null){
                return Ok(_mapper.Map<DeviceDto>(deviceModel));
            }
            return NotFound();
        }

        //POST api/devices
        //This request receives all the needed info to create a new Device in the devices database.
        [HttpPost]
        public ActionResult <DeviceDto> CreateDevice(DeviceDto deviceDto)
        {
            var deviceModel = _mapper.Map<Device>(deviceDto);
            _repository.AddDevice(deviceModel);

            var newDeviceDto = _mapper.Map<DeviceDto>(deviceModel);

            return CreatedAtRoute(nameof(GetDeviceBySerialNumber), new {serial_number = newDeviceDto.serial_number}, 
                                newDeviceDto);
        }

        //POST api/devices
        //This request receives all the needed info to create a new Device in the devices database.
        [HttpPost("state")]
        public ActionResult <DeviceStateDto> AddDeviceState(DeviceStateDto deviceStateDto)
        {
            var deviceStateModel = _mapper.Map<DeviceState>(deviceStateDto);
            _repository.AddDeviceState(deviceStateModel);

            var newDeviceStateDto = _mapper.Map<DeviceStateDto>(deviceStateModel);

            return CreatedAtRoute(nameof(GetDeviceBySerialNumber), new {serial_number = newDeviceStateDto.device_serial_number}, 
                                newDeviceStateDto);
        }

        
        //PUT api/dishes/{serial_number}
        //This request receives a JSON representing Device Entity to be updated. This JSON is mapped to a Device Data Model 
        //and with the serial_number received in the header of the request, the matching entity will be replaced with the new info.
        [HttpPut("{serial_number}")]
        public ActionResult UpdateDevice(int serial_number, DeviceDto deviceDto)
        {
            var deviceFromRepo = _repository.GetDevice(serial_number);
            deviceDto.serial_number = deviceFromRepo.serial_number;
            if(deviceFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(deviceDto, deviceFromRepo);
            _repository.UpdateDevice(deviceFromRepo);

            return NoContent();
        }

        //DELETE api/devices/{serial_number}
        //This request deletes the Device entity with the serial_number received in the request header.
        [HttpDelete("{serial_number}")]
        public ActionResult DeleteDevice(int serial_number)
        {
            var deviceFromRepo = _repository.GetDevice(serial_number);
            if(deviceFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteDevice(deviceFromRepo);
            return NoContent();
        }

    }
}