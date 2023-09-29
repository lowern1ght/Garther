using Garther.Domain.Models;
using Garther.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace Garther.Infrastructure.RequestHandlers;

public abstract class CommentsRequestHandlers
{
    public class CreateHandler : IRequestHandler<Requests.CommentsByTopic, IEnumerable<Comment>>
    {
        private readonly ILogger<CreateHandler> _logger;

        public CreateHandler(ILogger<CreateHandler> logger)
        {
            _logger = logger;
        }
        
        public Task<IEnumerable<Comment>> Handle(Requests.CommentsByTopic request, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}