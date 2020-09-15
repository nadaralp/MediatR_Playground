using MediatorTut.Services.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorTut.Services.Cars.Queries
{
    /// <summary>
    /// This is something to be used by mediator to trigger a call to the handler.
    /// </summary>
    public class GetAllCarsQuery : IRequest<IEnumerable<Car>>
    {
    }



    /// <summary>
    /// This is what's going to get triggered by MediatR
    /// </summary>
    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, IEnumerable<Car>>
    {

        // Gets the DI Container here
        public GetAllCarsQueryHandler()
        {

        }


        public async Task<IEnumerable<Car>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            List<Car> cars = new List<Car>();
            cars.Add(new Car { Name = "Ford" });
            cars.Add(new Car { Name = "Mercedes" });
            cars.Add(new Car { Name = "Ferrari" });

            return cars;
        }
    }
}
