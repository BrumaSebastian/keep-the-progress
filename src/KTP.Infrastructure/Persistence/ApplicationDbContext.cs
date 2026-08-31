using KTP.Domain.Modules.Entities.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KTP.Infrastructure.Persistence;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<ToDoItem> ToDoItems { get; private set; }
    public DbSet<ToDoItemDay> ToDoItemDays { get; private set; }
    public DbSet<PlanItem> PlanItems { get; private set; }
    public DbSet<Note> Notes { get; private set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
