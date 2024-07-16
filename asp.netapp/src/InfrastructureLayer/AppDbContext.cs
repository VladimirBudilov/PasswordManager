using DomainLayer;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Layer;

public class AppDbContext : DbContext
{
    public DbSet<PasswordEntry> PasswordEntries { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PasswordEntry>().HasKey(e => e.Id);
        modelBuilder.Entity<PasswordEntry>().Property(e => e.Name).IsRequired();
        modelBuilder.Entity<PasswordEntry>().Property(e => e.Password).IsRequired();
        modelBuilder.Entity<PasswordEntry>().Property(e => e.Type).IsRequired();
        modelBuilder.Entity<PasswordEntry>().Property(e => e.CreatedAt).IsRequired();
    }
}
