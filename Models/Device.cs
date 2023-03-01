namespace MaintenanceReminder.Models
{
    public class Device
    {
        public string Name { get; set; } = null!;
        public DateTime DateTimeOfLastMaintenance { get; set; }
        public DateTime DateTimeOfNextMaintenance { get; set; }

        public Device()
        {

        }
    }

}
