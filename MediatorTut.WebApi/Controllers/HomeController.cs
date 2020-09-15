using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatorTut.Services;
using MediatorTut.Services.Cars.Commands;
using MediatorTut.Services.Cars.Queries;
using MediatorTut.Services.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatorTut.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        // You return what the handler returns
        public async Task<IEnumerable<Car>> Index()
        {

            var cars = await _mediator.Send(new GetAllCarsQuery());
            // Could do more stuff with this here.
            return cars;
        }




        [HttpPost]
        public async Task<Response<Car>> CreateCar(CreateCarCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }

    }
}