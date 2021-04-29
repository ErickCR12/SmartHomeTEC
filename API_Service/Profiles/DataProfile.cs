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
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Distributor, DistributorDto>().ReverseMap();
            CreateMap<Distributor, DistributorDto>()
                .ForMember(s => s.legal_card, c => c.MapFrom(m => m.legal_card))
                .ForMember(s => s.name, c => c.MapFrom(m => m.name))
                .ForMember(s => s.devices, c => c.MapFrom(m => m.devices_))
                .ReverseMap();
        }
    }

}