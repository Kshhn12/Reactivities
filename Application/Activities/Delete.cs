using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Delete
    {
        public class command : IRequest
                {
                   public Guid Id { get; set; }
                }
        
                public class Handler : IRequestHandler<command>
                {
                    private readonly DataContext _context;
                    public Handler(DataContext context)
                    {
                        _context = context;
                    }
        
                    public async Task<Unit> Handle(command request, CancellationToken cancellationToken)
                    {
                        var activity = await _context.Activities.FindAsync(request.Id);

                        if(activity == null)
                            throw new RestException(HttpStatusCode.NotFound, new {activity = "Not Found"});

                        _context.Remove(activity);
                        
                        var success = await _context.SaveChangesAsync() > 0;
        
                        if (success) return Unit.Value;
        
                        throw new Exception("Problem saving changes");
                    }
                }
    }
}