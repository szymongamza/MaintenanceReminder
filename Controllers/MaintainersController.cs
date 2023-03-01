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

public class MaintainersController : Controller
{
    private readonly MaintenanceReminderContext _context;

    public MaintainersController(MaintenanceReminderContext context)
    {
        _context = context;
    }

    // GET: Maintainers
    public async Task<IActionResult> Index()
    {
        return _context.Maintainer != null ? 
            View(await _context.Maintainer.ToListAsync()) :
            Problem("Entity set 'MaintenanceReminderContext.Maintainer'  is null.");
    }

    // GET: Maintainers/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Maintainer == null)
        {
            return NotFound();
        }

        var maintainer = await _context.Maintainer
            .FirstOrDefaultAsync(m => m.Id == id);
        if (maintainer == null)
        {
            return NotFound();
        }

        return View(maintainer);
    }

    // GET: Maintainers/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Maintainers/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,ContactNumber,Email")] Maintainer maintainer)
    {
        if (ModelState.IsValid)
        {
            _context.Add(maintainer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(maintainer);
    }

    // GET: Maintainers/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Maintainer == null)
        {
            return NotFound();
        }

        var maintainer = await _context.Maintainer.FindAsync(id);
        if (maintainer == null)
        {
            return NotFound();
        }
        return View(maintainer);
    }

    // POST: Maintainers/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ContactNumber,Email")] Maintainer maintainer)
    {
        if (id != maintainer.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(maintainer);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaintainerExists(maintainer.Id))
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
        return View(maintainer);
    }

    // GET: Maintainers/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Maintainer == null)
        {
            return NotFound();
        }

        var maintainer = await _context.Maintainer
            .FirstOrDefaultAsync(m => m.Id == id);
        if (maintainer == null)
        {
            return NotFound();
        }

        return View(maintainer);
    }

    // POST: Maintainers/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Maintainer == null)
        {
            return Problem("Entity set 'MaintenanceReminderContext.Maintainer'  is null.");
        }
        var maintainer = await _context.Maintainer.FindAsync(id);
        if (maintainer != null)
        {
            _context.Maintainer.Remove(maintainer);
        }
            
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MaintainerExists(int id)
    {
        return (_context.Maintainer?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}