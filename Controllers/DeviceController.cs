using MaintenanceReminder.Models;
using Microsoft.AspNetCore.Mvc;

namespace MaintenanceReminder.Controllers
{
    public class DeviceController : Controller
    {
        private List<Device> _devices = new List<Device> { };
        public ActionResult Index()
        {
            var device = new Device();
            device.Name = "Urządzenie testowe";
            device.DateTimeOfLastMaintenance = DateTime.Now.AddDays(-1);
            device.DateTimeOfNextMaintenance = DateTime.Now;
            _devices.Add(device);
            return View(_devices);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] Device device)
        {
            if (ModelState.IsValid)
            {
                _devices.Add(device);
                return RedirectToAction("Index");
            }

            return View(device);
        }
    }
}
