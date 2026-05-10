using DietApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DietApi.Data;

public class DietDbContext : DbContext
{
    public DietDbContext(DbContextOptions<DietDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<DietCalculation> DietCalculations => Set<DietCalculation>();
    public DbSet<FeedbackMessage> FeedbackMessages => Set<FeedbackMessage>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasMany(user => user.Calculations)
            .WithOne(calculation => calculation.User)
            .HasForeignKey(calculation => calculation.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasIndex(user => user.Name);

        modelBuilder.Entity<DietCalculation>()
            .HasIndex(calculation => calculation.CreatedAt);

        modelBuilder.Entity<FeedbackMessage>()
            .HasIndex(message => message.CreatedAt);
    }
}
