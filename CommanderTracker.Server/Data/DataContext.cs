using CommanderTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CommanderTracker.Data;

public class DataContext(IConfiguration configuration) : IdentityDbContext<AppUser>
{
    protected readonly IConfiguration _configuration = configuration;

    public DbSet<AppUser> AppUsers { get; set; } = null!;
    public DbSet<Deck> Decks { get; set; } = null!;
    public DbSet<Game> Games { get; set; } = null!;
    public DbSet<Pilot> Pilots { get; set; } = null!;
    public DbSet<PlayInstance> PlayInstances { get; set; } = null!;
    public DbSet<PlayGroup> PlayGroups { get; set; } = null!;
    public DbSet<PlayGroupDeck> PlayGroupDecks { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("CommanderTrackerDatabase")).EnableSensitiveDataLogging(true); // TODO
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpsertTimestamps();
        return (await base.SaveChangesAsync(true, cancellationToken));
    }

    public override int SaveChanges() 
    {
        UpsertTimestamps();
        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // TODO

        /*
        List<IdentityRole> roles =
        [
            new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Name = "User", NormalizedName = "USER" }
        ];

        builder.Entity<IdentityRole>().HasData(roles);
        */
        
        builder.Entity<AppUser>()
            .HasMany(e => e.Pilots)
            .WithOne(e => e.AppUser)
            .HasForeignKey(e => e.AppUserId)
            .HasPrincipalKey(e => e.Id);

        builder.Entity<AppUser>()
            .HasMany(e => e.Decks)
            .WithOne(e => e.CreatedBy)
            .HasForeignKey(e => e.CreatedById)
            .HasPrincipalKey(e => e.Id);

        builder.Entity<AppUser>()
            .HasMany(e => e.Games)
            .WithOne(e => e.CreatedBy)
            .HasForeignKey(e => e.CreatedById)
            .HasPrincipalKey(e => e.Id);
        
        builder.Entity<AppUser>()
            .HasMany(e => e.CreatedPilots)
            .WithOne(e => e.CreatedBy)
            .HasForeignKey(e => e.CreatedById)
            .HasPrincipalKey(e => e.Id);

        builder.Entity<AppUser>()
            .HasMany(e => e.PlayGroups)
            .WithOne(e => e.CreatedBy)
            .HasForeignKey(e => e.CreatedById)
            .HasPrincipalKey(e => e.Id);

        builder.Entity<AppUser>()
            .HasMany(e => e.PlayInstances)
            .WithOne(e => e.CreatedBy)
            .HasForeignKey(e => e.CreatedById)
            .HasPrincipalKey(e => e.Id);
    }

    private void UpsertTimestamps()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(entry =>
                entry.Entity is BaseEntity &&
                (entry.State == EntityState.Added || entry.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            ((BaseEntity)entry.Entity).UpdatedDate = DateTime.UtcNow;

            if (entry.State == EntityState.Added)
            {
                ((BaseEntity)entry.Entity).CreatedDate = DateTime.UtcNow;
            }
        }
    }
}

