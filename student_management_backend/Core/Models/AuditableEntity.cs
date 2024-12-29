using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace student_management_backend.Core.Models;

public abstract class AuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default;
    public DateTime CreatedDate { get; private set; }
    public DateTime? DeletedDate { get; set; }

    protected AuditableEntity()
    {
        CreatedDate = DateTime.UtcNow;
    }
}