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
    public class ReportsController: ControllerBase
    {
        private readonly ISmartHomeRepo _repository;
        private readonly IMapper _mapper;

        public ReportsController (ISmartHomeRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        //GET api/dashboard/activeDevices   
        //This request returns a numerical value representing the amount of devices per user.
        [HttpGet("monthlyUsage/{email}")]
        public ActionResult <NumericalDto> GetMonthlyUsage(string email)
        {
            var monthlyUsageValue = _repository.GetMonthlyUsage(email);
            NumericalDto monthlyUsageDto = new NumericalDto();
            monthlyUsageDto.numerical_value = monthlyUsageValue;
            return Ok(monthlyUsageDto);
        }

        [HttpGet("deviceTypesUsage/{email}")]
        public ActionResult <IEnumerable<ReportDto>> GetDeviceTypesUsage(string email)
        {
            var deviceTypesUsageValue = _repository.GetDeviceTypesUsage(email);

            return Ok(_mapper.Map<IEnumerable<ReportDto>>(deviceTypesUsageValue));
        }

        [HttpGet("dailyUsage/{email}")]
        public ActionResult <IEnumerable<ReportDto>> GetDailyUsage(string email)
        {
            var dailyUsageValue = _repository.GetDailyUsage(email);

            return Ok(_mapper.Map<IEnumerable<ReportDto>>(dailyUsageValue));
        }


    }
}