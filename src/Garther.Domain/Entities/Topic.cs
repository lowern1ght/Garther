using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garther.Domain.Entities;

public class Topic
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public Guid ForumId { get; set; }
    public Forum Forum  { get; set; }

    public Guid UserId { get; set; }
    public User User   { get; set; }
    
    public ICollection<Comment> Comments { get; set; } = null!;
}