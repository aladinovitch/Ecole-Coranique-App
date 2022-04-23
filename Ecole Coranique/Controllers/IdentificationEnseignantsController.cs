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
using static Ecole_Coranique.Helpers.Helpers;

namespace Ecole_Coranique.Controllers
{
    public class IdentificationEnseignantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IdentificationEnseignantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IdentificationEnseignants
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.IdentificationEnseignants.Include(i => i.Enseignant).Include(i => i.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: IdentificationEnseignants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identificationEnseignant = await _context.IdentificationEnseignants
                .Include(i => i.Enseignant)
                .Include(i => i.IdentityUser)
                .FirstOrDefaultAsync(m => m.EnseignantId == id);
            if (identificationEnseignant == null)
            {
                return NotFound();
            }

            return View(identificationEnseignant);
        }

        // GET: IdentificationEnseignants/Create
        public IActionResult Create()
        {
            ViewData["EnseignantId"] = new SelectList(EnseignantsNotAlreadyListed(_context), "Id", "Fullname");
            ViewData["IdentityUserId"] = new SelectList(IdentityUsersNotAlreadyListed(_context), "Id", "UserName");
            return View();
        }

        // POST: IdentificationEnseignants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnseignantId,IdentityUserId")] IdentificationEnseignant identificationEnseignant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(identificationEnseignant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnseignantId"] = new SelectList(_context.Enseignants, "Id", "Fullname", identificationEnseignant.EnseignantId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "UserName", identificationEnseignant.IdentityUserId);
            return View(identificationEnseignant);
        }

        // GET: IdentificationEnseignants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identificationEnseignant = await _context.IdentificationEnseignants.FindAsync(id);
            if (identificationEnseignant == null)
            {
                return NotFound();
            }
            ViewData["EnseignantId"] = new SelectList(_context.Enseignants, "Id", "Fullname", identificationEnseignant.EnseignantId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "UserName", identificationEnseignant.IdentityUserId);
            return View(identificationEnseignant);
        }

        // POST: IdentificationEnseignants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnseignantId,IdentityUserId")] IdentificationEnseignant identificationEnseignant)
        {
            if (id != identificationEnseignant.EnseignantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(identificationEnseignant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdentificationEnseignantExists(identificationEnseignant.EnseignantId))
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
            ViewData["EnseignantId"] = new SelectList(_context.Enseignants, "Id", "Fullname", identificationEnseignant.EnseignantId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "UserName", identificationEnseignant.IdentityUserId);
            return View(identificationEnseignant);
        }

        // GET: IdentificationEnseignants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identificationEnseignant = await _context.IdentificationEnseignants
                .Include(i => i.Enseignant)
                .Include(i => i.IdentityUser)
                .FirstOrDefaultAsync(m => m.EnseignantId == id);
            if (identificationEnseignant == null)
            {
                return NotFound();
            }

            return View(identificationEnseignant);
        }

        // POST: IdentificationEnseignants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var identificationEnseignant = await _context.IdentificationEnseignants.FindAsync(id);
            _context.IdentificationEnseignants.Remove(identificationEnseignant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdentificationEnseignantExists(int id)
        {
            return _context.IdentificationEnseignants.Any(e => e.EnseignantId == id);
        }
    }
}
