using Microsoft.AspNetCore.Mvc;
using API_Service.Data;
using AutoMapper;
using API_Service.DTOs;
using System.Collections.Generic;
using API_Service.Models;
using System;

namespace API_Service.Controllers
{

    //This is an API Controller for the Client entity type. 
    //This Controller allows a GET request to obtain all the Clients in the database, a POST request to create a new client.
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ISmartHomeRepo _repository;
        private readonly IMapper _mapper;

        public ClientsController (ISmartHomeRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        //GET api/clients
        //This request returns a list of Client entities in a JSON format representing the chef database.
        [HttpGet]
        public ActionResult <IEnumerable<ClientDto>> GetAllClients()
        {
            var clientsItem = _repository.GetAllClients();
            return Ok(_mapper.Map<IEnumerable<ClientDto>>(clientsItem));
        }

        //GET api/clients/{serial_number}
        //This request returns a single Client entity in a JSON format. This entity has the same serial number
        //as the received in the request header.
        [HttpGet("{email}", Name = "GetClientByEmail")]
        public ActionResult <ClientDto> GetClientByEmail(string email)
        {
            var clientModel = _repository.GetClient(email);
            if(clientModel != null){
                return Ok(_mapper.Map<ClientDto>(clientModel));
            }
            return NotFound();
        }

        //POST api/clients
        //This request receives all the needed info to create a new Client in the clients database.
        [HttpPost]
        public ActionResult <ClientDto> CreateClient(ClientDto clientDto)
        {
            var clientModel = _mapper.Map<Client>(clientDto);
            _repository.AddClient(clientModel);

            var directionClientModel = new DirectionClient();
            directionClientModel.client_email = clientDto.email;
            directionClientModel.direction = clientDto.direction;
            _repository.AddDirection(directionClientModel);

            var newClientDto = _mapper.Map<ClientDto>(clientModel);

            return CreatedAtRoute(nameof(GetClientByEmail), new {email = newClientDto.email}, 
                                newClientDto);
        }

        [HttpPost("direction")]
        public ActionResult <DirectionClientDto> AddDirection(DirectionClientDto directionClientDto)
        {
            var directionClientModel = _mapper.Map<DirectionClient>(directionClientDto);
            _repository.AddDirection(directionClientModel);

            var newDirectionClientDto = _mapper.Map<DirectionClientDto>(directionClientModel);

            return CreatedAtRoute(nameof(GetClientByEmail), new {email = newDirectionClientDto.client_email}, 
                                newDirectionClientDto);
        }

        [HttpPut("{client_email}")]
        public ActionResult UpdateClient(string client_email, ClientDto clientDto)
        {
            var clientFromRepo = _repository.GetClient(client_email);
            clientDto.email = clientFromRepo.email;
            if(clientFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(clientDto, clientFromRepo);
            _repository.UpdateClient(clientFromRepo);

            return NoContent();
        }

    }
}