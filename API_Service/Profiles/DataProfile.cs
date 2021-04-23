using AutoMapper;
using API_Service.Models;
using API_Service.DTOs;

namespace WebServiceResTEC.Profiles
{

    //This class set all the available mapping for the data models of the database.
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<Device, DeviceDto>().ReverseMap();
            CreateMap<DeviceType, DeviceTypeDto>().ReverseMap();

        }
    }

}