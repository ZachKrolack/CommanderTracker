﻿using CommanderTracker.Models;

namespace CommanderTracker.DTOs;

public abstract class BaseResponseDTO : IEntityDate
{
    public Guid Id { get; set; }
    public virtual DateTime CreatedDate { get; set; }
    public virtual DateTime UpdatedDate { get; set; }
    // public virtual AppUserResponseDTO CreatedBy { get; set; } = null!; // TODO
    public virtual string? CreatedById { get; set; } // TODO
    public virtual string? UpdatedById { get;set; } // TODO
}
