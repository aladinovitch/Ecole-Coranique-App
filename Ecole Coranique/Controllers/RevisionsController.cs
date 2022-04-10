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
using Microsoft.AspNetCore.Authorization;

namespace Ecole_Coranique.Controllers
{
    [Authorize(Policy = AppPolicyName.Accessing)]
    public class RevisionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RevisionsController(ApplicationDbContext context) {
            _context = context;
        }

        // GET: Revisions
        public async Task<IActionResult> Index() {
            var applicationDbContext = _context.Revisions.Include(r => r.Etudiant).Include(r => r.Hizb).Include(r => r.Huitieme);
            if (User.HasClaim(AppClaimType.Manager, "true"))
                return View(await applicationDbContext.ToListAsync());
            return View("IndexReadOnly", await applicationDbContext.ToListAsync());
        }

        [Authorize(Policy = AppPolicyName.Management)]
        // GET: Revisions/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var revision = await _context.Revisions
                .Include(r => r.Etudiant)
                .Include(r => r.Hizb)
                .Include(r => r.Huitieme)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (revision == null) {
                return NotFound();
            }

            return View(revision);
        }

        [Authorize(Policy = AppPolicyName.Management)]
        // GET: Revisions/Create
        public IActionResult Create() {
            ViewData["EtudiantId"] = new SelectList(_context.Etudiants, "Id", "Fullname");
            ViewData["HizbId"] = new SelectList(_context.Hizbs, "Id", "Nom");
            ViewData["HuitiemeId"] = new SelectList(_context.Huitiemes, "Id", "Nom");
            return View();
        }

        // POST: Revisions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,EtudiantId,HizbId,HuitiemeId")] Revision revision) {
            if (ModelState.IsValid) {
                _context.Add(revision);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EtudiantId"] = new SelectList(_context.Etudiants, "Id", "Fullname", revision.EtudiantId);
            ViewData["HizbId"] = new SelectList(_context.Hizbs, "Id", "Nom", revision.HizbId);
            ViewData["HuitiemeId"] = new SelectList(_context.Huitiemes, "Id", "Nom", revision.HuitiemeId);
            return View(revision);
        }

        [Authorize(Policy = AppPolicyName.Management)]
        // GET: Revisions/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var revision = await _context.Revisions.FindAsync(id);
            if (revision == null) {
                return NotFound();
            }
            ViewData["EtudiantId"] = new SelectList(_context.Etudiants, "Id", "Fullname", revision.EtudiantId);
            ViewData["HizbId"] = new SelectList(_context.Hizbs, "Id", "Nom", revision.HizbId);
            ViewData["HuitiemeId"] = new SelectList(_context.Huitiemes, "Id", "Nom", revision.HuitiemeId);
            return View(revision);
        }

        // POST: Revisions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,EtudiantId,HizbId,HuitiemeId")] Revision revision) {
            if (id != revision.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(revision);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!RevisionExists(revision.Id)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EtudiantId"] = new SelectList(_context.Etudiants, "Id", "Fullname", revision.EtudiantId);
            ViewData["HizbId"] = new SelectList(_context.Hizbs, "Id", "Nom", revision.HizbId);
            ViewData["HuitiemeId"] = new SelectList(_context.Huitiemes, "Id", "Nom", revision.HuitiemeId);
            return View(revision);
        }

        [Authorize(Policy = AppPolicyName.Management)]
        // GET: Revisions/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var revision = await _context.Revisions
                .Include(r => r.Etudiant)
                .Include(r => r.Hizb)
                .Include(r => r.Huitieme)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (revision == null) {
                return NotFound();
            }

            return View(revision);
        }

        // POST: Revisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var revision = await _context.Revisions.FindAsync(id);
            _context.Revisions.Remove(revision);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RevisionExists(int id) {
            return _context.Revisions.Any(e => e.Id == id);
        }
    }
}
