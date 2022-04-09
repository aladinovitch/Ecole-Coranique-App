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
    public class HizbsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HizbsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hizbs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hizbs.ToListAsync());
        }

        // GET: Hizbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hizb = await _context.Hizbs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hizb == null)
            {
                return NotFound();
            }

            return View(hizb);
        }

        // GET: Hizbs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hizbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,Nom,Description")] Hizb hizb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hizb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hizb);
        }

        // GET: Hizbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hizb = await _context.Hizbs.FindAsync(id);
            if (hizb == null)
            {
                return NotFound();
            }
            return View(hizb);
        }

        // POST: Hizbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,Nom,Description")] Hizb hizb)
        {
            if (id != hizb.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hizb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HizbExists(hizb.Id))
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
            return View(hizb);
        }

        // GET: Hizbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hizb = await _context.Hizbs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hizb == null)
            {
                return NotFound();
            }

            return View(hizb);
        }

        // POST: Hizbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hizb = await _context.Hizbs.FindAsync(id);
            _context.Hizbs.Remove(hizb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HizbExists(int id)
        {
            return _context.Hizbs.Any(e => e.Id == id);
        }
    }
}
