#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ecole_Coranique.Data;
using Ecole_Coranique.Models;

namespace Ecole_Coranique.Controllers
{
    public class HuitiemesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HuitiemesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Huitiemes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Huitiemes.ToListAsync());
        }

        // GET: Huitiemes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huitieme = await _context.Huitiemes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (huitieme == null)
            {
                return NotFound();
            }

            return View(huitieme);
        }

        // GET: Huitiemes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Huitiemes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,Nom")] Huitieme huitieme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(huitieme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(huitieme);
        }

        // GET: Huitiemes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huitieme = await _context.Huitiemes.FindAsync(id);
            if (huitieme == null)
            {
                return NotFound();
            }
            return View(huitieme);
        }

        // POST: Huitiemes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,Nom")] Huitieme huitieme)
        {
            if (id != huitieme.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(huitieme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HuitiemeExists(huitieme.Id))
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
            return View(huitieme);
        }

        // GET: Huitiemes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huitieme = await _context.Huitiemes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (huitieme == null)
            {
                return NotFound();
            }

            return View(huitieme);
        }

        // POST: Huitiemes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var huitieme = await _context.Huitiemes.FindAsync(id);
            _context.Huitiemes.Remove(huitieme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HuitiemeExists(int id)
        {
            return _context.Huitiemes.Any(e => e.Id == id);
        }
    }
}
