using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MaintenanceReminder.Data;
using MaintenanceReminder.Models;

namespace MaintenanceReminder.Controllers;

public class DevicesController : Controller
{
    private readonly MaintenanceReminderContext _context;

    public DevicesController(MaintenanceReminderContext context)
    {
        _context = context;
    }

    // GET: Devices
    public async Task<IActionResult> Index()
    {
        var maintenanceReminderContext = _context.Device
            .Include(d => d.Maintainer)
            .Include(d => d.Manufacturer)
            .Include(d => d.Place)
            .OrderBy(x=>x.DateTimeOfNextMaintenance);
        return View(await maintenanceReminderContext.ToListAsync());
    }

    // GET: Devices/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Device == null)
        {
            return NotFound();
        }

        var device = await _context.Device
            .Include(d => d.Maintainer)
            .Include(d => d.Manufacturer)
            .Include(d => d.Place)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (device == null)
        {
            return NotFound();
        }

        return View(device);
    }

    // GET: Devices/Create
    public IActionResult Create()
    {
        ViewData["MaintainerId"] = new SelectList(_context.Maintainer, "Id", "Name");
        ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "Id", "Name");
        ViewData["PlaceId"] = new SelectList(_context.Place, "Id", "Name");
        return View();
    }

    // POST: Devices/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Description,SerialNumber,ManufacturerId,MaintainerId,DateTimeOfLastMaintenance,DateTimeOfNextMaintenance,PlaceId")] Device device)
    {
        if (ModelState.IsValid)
        {
            _context.Add(device);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["MaintainerId"] = new SelectList(_context.Maintainer, "Id", "Name", device.MaintainerId);
        ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "Id", "Name", device.ManufacturerId);
        ViewData["PlaceId"] = new SelectList(_context.Place, "Id", "Name", device.PlaceId);
        return View(device);
    }

    // GET: Devices/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Device == null)
        {
            return NotFound();
        }

        var device = await _context.Device.FindAsync(id);
        if (device == null)
        {
            return NotFound();
        }
        ViewData["MaintainerId"] = new SelectList(_context.Maintainer, "Id", "Name", device.MaintainerId);
        ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "Id", "Name", device.ManufacturerId);
        ViewData["PlaceId"] = new SelectList(_context.Place, "Id", "Name", device.PlaceId);
        return View(device);
    }

    // POST: Devices/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,SerialNumber,ManufacturerId,MaintainerId,DateTimeOfLastMaintenance,DateTimeOfNextMaintenance,PlaceId")] Device device)
    {
        if (id != device.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(device);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(device.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["MaintainerId"] = new SelectList(_context.Maintainer, "Id", "Name", device.MaintainerId);
        ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "Id", "Name", device.ManufacturerId);
        ViewData["PlaceId"] = new SelectList(_context.Place, "Id", "Name", device.PlaceId);
        return View(device);
    }

    // GET: Devices/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Device == null)
        {
            return NotFound();
        }

        var device = await _context.Device
            .Include(d => d.Maintainer)
            .Include(d => d.Manufacturer)
            .Include(d => d.Place)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (device == null)
        {
            return NotFound();
        }

        return View(device);
    }

    // POST: Devices/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Device == null)
        {
            return Problem("Entity set 'MaintenanceReminderContext.Device'  is null.");
        }
        var device = await _context.Device.FindAsync(id);
        if (device != null)
        {
            _context.Device.Remove(device);
        }
            
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DeviceExists(int id)
    {
        return (_context.Device?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}