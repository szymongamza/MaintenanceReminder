using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceReminder.Models;

public class Device
{
    public int Id { get; set; }
    [DisplayName("Nazwa")]
    public string Name { get; set; } = null!;
    [DisplayName("Opis")]
    public string? Description { get; set; }
    [DisplayName("Numer Seryjny")]
    public string? SerialNumber { get; set; }
    public int? ManufacturerId { get; set; }
    [DisplayName("Producent")]
    public Manufacturer? Manufacturer { get; set; }
    public int? MaintainerId { get; set; }
    [DisplayName("Serwis")]
    public Maintainer? Maintainer { get; set; }
    public int? PlaceId { get; set; }
    [DisplayName("Miejsce")]
    public Place? Place { get; set; }

    [DataType(DataType.Date)]
    [DisplayName("Ostatni przegląd")]
    public DateTime DateTimeOfLastMaintenance { get; set; }
    [DataType(DataType.Date)]
    [DisplayName("Następny przegląd")]
    public DateTime DateTimeOfNextMaintenance { get; set; }

}