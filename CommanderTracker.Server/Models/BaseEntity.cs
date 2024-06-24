using System.ComponentModel.DataAnnotations.Schema;

namespace CommanderTracker.Models;

interface IEntityDate
{
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}

interface IEntityCreator
{
    public string CreatedById { get; set; }
    public AppUser CreatedBy { get; set; }
    
}

interface IEntityUpdater 
{
    public string UpdatedById { get; set; }
    public AppUser UpdatedBy { get; set; }
}

public abstract class BaseEntity : IEntityDate, IEntityCreator, IEntityUpdater
{
    [Column("id")]
    public Guid Id { get; set; }

    [Column("created_date")]
    public virtual DateTime CreatedDate { get; set; }

    [Column("updated_date")]
    public virtual DateTime UpdatedDate { get; set; }

    [Column("created_by_id")]
    public string CreatedById { get; set; } = string.Empty;
    public AppUser CreatedBy { get; set; } = null!;

    [Column("updated_by_id")]
    public string UpdatedById { get; set; } = string.Empty;
    public AppUser UpdatedBy { get; set; } = null!;
}
