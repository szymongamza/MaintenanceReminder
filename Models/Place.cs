using System.ComponentModel;

namespace MaintenanceReminder.Models;

public class Place
{
    public int Id { get; set; }
    [DisplayName("Nazwa")]
    public string Name { get; set; } = null!;
    public ICollection<Device> Devices { get; set; } = new List<Device>();
}
