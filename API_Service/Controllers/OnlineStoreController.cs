using Microsoft.AspNetCore.Mvc;
using API_Service.Data;
using AutoMapper;
using API_Service.DTOs;
using System.Collections.Generic;
using API_Service.Models;
using System;

namespace API_Service.Controllers
{

    //This is an API Controller for the device_distributor entity type.
    [Route("api/[controller]")]
    [ApiController]
    public class OnlineStoreController : ControllerBase
    {
        private readonly ISmartHomeRepo _repository;
        private readonly IMapper _mapper;

        public OnlineStoreController (ISmartHomeRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        //POST api/onlineStore/distributors
        //This request returns a list of Distributor entities in a JSON format representing the device_distributor database.
        [HttpPost("distributors")]
        public ActionResult <IEnumerable<DistributorDto>> GetOnlineStore(RegionDto regionDto)
        {
            var onlineStore = _repository.GetOnlineStore(regionDto.continent, regionDto.country);
            return Ok(_mapper.Map<IEnumerable<DistributorDto>>(onlineStore));
        }

        //POST api/onlineStore
        //This request receives all the needed info to create new entries in device_distributor database.
        [HttpPost(Name = "CreateOnlineStore")]
        public ActionResult <IEnumerable<DeviceTypeDto>> CreateOnlineStore(IEnumerable<DistributorDto> onlineStoreDto)
        {
            var distributorsModel = _mapper.Map<IEnumerable<Distributor>>(onlineStoreDto);
            _repository.AddOnlineStore(distributorsModel);

            return Created(nameof(CreateOnlineStore), onlineStoreDto);
        }
    }
}