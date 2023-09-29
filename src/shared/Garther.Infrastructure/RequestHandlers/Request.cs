using Garther.Infrastructure.Interfaces;
using Comment = Garther.Domain.Models.Comment;

namespace Garther.Infrastructure.RequestHandlers;

public abstract class Requests
{
    public class CommentsByTopic : IRequest<IEnumerable<Comment>>
    {
        public Guid TopicId { get; set; }
        
        public CommentsByTopic(Guid topicId)
        {
            TopicId = topicId;
        }
    }
}