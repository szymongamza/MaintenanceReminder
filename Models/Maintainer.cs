using System.ComponentModel;

namespace MaintenanceReminder.Models;

public class Maintainer
{
    public int Id { get; set; }
    [DisplayName("Nazwa")]
    public string Name { get; set; } = null!;
    [DisplayName("Numer kontaktowy")]
    public string? ContactNumber { get; set; }
    public string? Email { get; set; }
    public ICollection<Device> Devices { get; set; } = new List<Device>();
}
