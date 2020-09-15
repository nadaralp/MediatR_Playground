using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorTut.Services.Cars.Commands
{
    public class CreateCarCommand : IRequest<string>
    {
    }


    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, string>
    {
        public async Task<string> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            return "new car was created";
        }
    }

}
