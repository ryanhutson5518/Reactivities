using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Activity.Id);

                //activity.Title = request.Activity.Title ?? activity.Title;   // This code will edit the title if the user does a PUT request to update the title. Without AutoMapper, we would have to do this for every property

                _mapper.Map(request.Activity, activity);   // This takes away lots of manual code written

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
