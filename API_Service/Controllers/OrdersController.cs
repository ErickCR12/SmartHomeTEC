using Microsoft.AspNetCore.Mvc;
using API_Service.Data;
using AutoMapper;
using API_Service.DTOs;
using System.Collections.Generic;
using API_Service.Models;
using System;

namespace API_Service.Controllers
{

    //This is an API Controller for the Order entity type. 
    //This Controller allows a  a POST request to create a new Order.
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ISmartHomeRepo _repository;
        private readonly IMapper _mapper;

        public OrdersController (ISmartHomeRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        //POST api/orders
        //This request receives all the needed info to create a new Order in the orders database.
        [HttpPost(Name = "CreateOrder")]
        public ActionResult <OrderDto> CreateOrder(OrderDto orderDto)
        {
            var orderModel = _mapper.Map<Order>(orderDto);
            _repository.AddOrder(orderModel);

            var newOrderDto = _mapper.Map<OrderDto>(orderModel);

            return CreatedAtRoute(nameof(CreateOrder), new {consecutive = newOrderDto.consecutive}, 
                                newOrderDto);
        }

    }
}