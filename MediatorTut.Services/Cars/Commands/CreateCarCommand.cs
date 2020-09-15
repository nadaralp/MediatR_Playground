using MediatorTut.Services.Common;
using MediatorTut.Services.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorTut.Services.Cars.Commands
{
    public class CreateCarCommand : BaseRequest, IRequest<Response<Car>>
    {
    }


    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Response<Car>>
    {
        public async Task<Response<Car>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            // If car creation failed
            if (false)
            {
                Response.Fail<Car>("Already exists");
            }


            var car = new Car
            {
                Name = "Toyota"
            };

            return Response.Ok(car, "Car was created successfully");

        }
    }

}
