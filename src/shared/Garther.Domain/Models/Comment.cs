namespace Garther.Domain.Models;

public class Comment
{
    public Comment(Guid id, string text)
    {
        Id = id;
        Text = text;
    }

    public Guid Id { get; set; }
    public string Text { get; set; }
}