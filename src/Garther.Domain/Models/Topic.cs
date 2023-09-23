namespace Garther.Domain.Models;

public class Topic
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    public Topic(Guid id, string title, User user)
    {
        Id = id;
        Title = title;
    }
}