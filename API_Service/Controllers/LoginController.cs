using API_Service.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using API_Service.DTOs;
using API_Service.Models;

namespace WebServiceResTEC.Controllers
{

    //This is an API Controller for validation of the Login credentials. This Controller allows a POST request.
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ISmartHomeRepo _repository;
        private readonly IMapper _mapper;

        public LoginController(ISmartHomeRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        //POST api/login
        //This POST request receives a JSON representing the LoginProfile Data Model. It will return the type of user
        //by checking the username and password in the JSON.
        [HttpPost]
        public ActionResult <LoginDto> CheckCredentials(LoginDto loginDto)
        {
            var loginProfile = _mapper.Map<LoginProfile>(loginDto);
            LoginProfile user = _repository.CheckCredentials(loginProfile);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<LoginDto>(user));

        }
    }
}