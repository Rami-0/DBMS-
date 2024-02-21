using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBMS.Models;

namespace DBMS.Controllers
{
    public class MonthsController : Controller
    {
        private readonly DBMSContext _context;

        public MonthsController(DBMSContext context)
        {
            _context = context;
        }

        // GET: Months
        public async Task<IActionResult> Index()
        {
            return View(await _context.Months.ToListAsync());
        }

        // GET: Months/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var months = await _context.Months
                .FirstOrDefaultAsync(m => m.Id == id);
            if (months == null)
            {
                return NotFound();
            }

            return View(months);
        }

        // GET: Months/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Months/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MonthName")] Months months)
        {
            if (ModelState.IsValid)
            {
                _context.Add(months);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(months);
        }

        // GET: Months/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var months = await _context.Months.FindAsync(id);
            if (months == null)
            {
                return NotFound();
            }
            return View(months);
        }

        // POST: Months/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("Id,MonthName")] Months months)
        {
            if (id != months.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(months);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonthsExists(months.Id))
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
            return View(months);
        }

        // GET: Months/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var months = await _context.Months
                .FirstOrDefaultAsync(m => m.Id == id);
            if (months == null)
            {
                return NotFound();
            }

            return View(months);
        }

        // POST: Months/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var months = await _context.Months.FindAsync(id);
            _context.Months.Remove(months);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonthsExists(byte id)
        {
            return _context.Months.Any(e => e.Id == id);
        }
    }
}
