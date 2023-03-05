using MaintenanceReminder.Data;
using Microsoft.EntityFrameworkCore;
using Quartz;

namespace MaintenanceReminder.BackgroundServices;

public class CheckDaysTillEndOfMaintenance : IJob
{
    private readonly MaintenanceReminderContext _context;

    public CheckDaysTillEndOfMaintenance(MaintenanceReminderContext context)
    {
        _context = context;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var devices = await _context.Device.ToListAsync();
        foreach (var device in devices)
        {
            if (device.DaysTillEndOfMaintenance() < 3)
                Console.WriteLine(device.Name);
        }
    }
}
