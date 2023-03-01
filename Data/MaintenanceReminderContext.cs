using Microsoft.EntityFrameworkCore;
using MaintenanceReminder.Models;

namespace MaintenanceReminder.Data;

public class MaintenanceReminderContext : DbContext
{
    public MaintenanceReminderContext (DbContextOptions<MaintenanceReminderContext> options)
        : base(options)
    {
    }

    public DbSet<Manufacturer> Manufacturer { get; set; } = default!;

    public DbSet<Maintainer> Maintainer { get; set; } = default!;

    public DbSet<Device> Device { get; set; } = default!;

    public DbSet<Place> Place { get; set; } = default!;
}