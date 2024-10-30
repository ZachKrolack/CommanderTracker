using CommanderTracker.Models;

namespace CommanderTracker.DTOs;

public abstract class BaseResponseDTO : IEntityDate
{
    public Guid Id { get; set; }
    public virtual DateTime CreatedDate { get; set; }
    public virtual DateTime UpdatedDate { get; set; }
    // public virtual AppUserResponseDTO CreatedBy { get; set; } = null!; // TODO
}
