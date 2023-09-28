using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garther.Forum.Database.Entities;

public class Forum
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required] public string? Title { get; set; }

    public ICollection<Topic> Topics { get; set; } = null!;
}