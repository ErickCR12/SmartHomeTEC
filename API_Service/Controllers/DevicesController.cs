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
        public ActionResult <DeviceDto> GetAllDevices()
        {
            var devicesItem = _repository.GetAllDevices();
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
        //This request returns a list of Chef entities in a JSON format representing the chef database.
        [HttpPost]
        public ActionResult <DeviceDto> CreateDevice(DeviceDto deviceDto)
        {
            Console.WriteLine(deviceDto.serial_number);
            Console.WriteLine(deviceDto.device_type_name);
            var deviceModel = _mapper.Map<Device>(deviceDto);
            _repository.AddDevice(deviceModel);

            var newDeviceDto = _mapper.Map<DeviceDto>(deviceModel);

            return CreatedAtRoute(nameof(GetDeviceBySerialNumber), new {SerialNumber = newDeviceDto.serial_number}, 
                                newDeviceDto);
        }

        
        //PUT api/dishes/{id}
        //This request receives a JSON representing Dish Entity to be updated. This JSON is mapped to a Dish Data Model 
        //and with the id received in the header of the request, the matching entity will be replaced with the new info.
        [HttpPut("{serial_number}")]
        public ActionResult UpdateDish(int serial_number, DeviceDto deviceDto)
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

        //DELETE api/dishes/{id}
        //This request deletes the Dish entity with the id received in the request header.
        [HttpDelete("{serial_number}")]
        public ActionResult DeleteDish(int serial_number)
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