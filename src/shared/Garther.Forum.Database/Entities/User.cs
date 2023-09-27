using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garther.Forum.Database.Entities;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public ICollection<Topic> Topics { get; set; } = null!;
    public ICollection<Comment> Comments { get; set; } = null!;
}