using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceReminder.Models;

public class Manufacturer
{
    public int Id { get; set; }
    [DisplayName("Nazwa")]
    public string Name { get; set; } = null!;
    public ICollection<Device> Devices { get; set; } = new List<Device>();
}