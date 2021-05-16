using Microsoft.AspNetCore.Mvc;
using API_Service.Data;
using AutoMapper;
using API_Service.DTOs;
using System.Collections.Generic;
using API_Service.Models;
using System;

namespace API_Service.Controllers
{

    //This is an API Controller for the admin dashboard.
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ISmartHomeRepo _repository;
        private readonly IMapper _mapper;

        public DashboardController (ISmartHomeRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        //GET api/dashboard/devicePerUser
        //This request returns a numerical value representing the amount of devices per user.
        [HttpGet("devicesPerUser")]
        public ActionResult <NumericalDto> GetDevicePerUser()
        {
            var devicesPerUser = _repository.GetDevicesPerUser();
            return Ok(_mapper.Map<DevicesPerUserDto>(devicesPerUser));
        }

        //GET api/dashboard/devicePerUser
        //This request returns a list of devices that exist in the shop for the specified region.
        [HttpGet("devicesPerRegion")]
        public ActionResult <IEnumerable<RegionDto>> GetDevicesPerRegion()
        {
            var devicePerRegionValue = _repository.GetDevicesPerRegion();

            return Ok(_mapper.Map<IEnumerable<RegionDto>>(devicePerRegionValue));
        }

        //GET api/dashboard/activeDevices   
        //This request returns a numerical value representing the active devices.
        [HttpGet("activeDevices")]
        public ActionResult <NumericalDto> GetActiveDevices()
        {
            var activeDevicesValue = _repository.GetActiveDevices();
            NumericalDto activeDevicesDto = new NumericalDto();
            activeDevicesDto.numerical_value = activeDevicesValue;
            return Ok(activeDevicesDto);
        }

    }
}