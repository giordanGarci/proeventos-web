using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Context;

public class ProEventosContext : DbContext
{

    public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options) { }
    public DbSet<Event> Events { get; set; }
    public DbSet<Batch> Batchs { get; set; }
    public DbSet<Speaker> Speakers { get; set; }
    public DbSet<SpeakerEvent> SpeakersEvents { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SpeakerEvent>()
            .HasKey(se => new { se.EventId, se.SpeakerId });

        modelBuilder.Entity<Event>()
            .HasMany(e => e.SocialMedias)
            .WithOne(sm => sm.Event)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Speaker>()
            .HasMany(s => s.SocialMedias)
            .WithOne(sm => sm.Speaker)
            .OnDelete(DeleteBehavior.Cascade);
            
        modelBuilder.Entity<Event>()
            .HasMany(e => e.Batches)
            .WithOne(b => b.Event)
            .OnDelete(DeleteBehavior.Cascade);
            
    }

}