using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garther.Domain.Entities;

public record class Forum
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    public string Title { get; set; }

    public ICollection<Topic> Topics { get; set; } = null!;
}