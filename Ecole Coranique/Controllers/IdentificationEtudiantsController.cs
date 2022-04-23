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
    public class IdentificationEtudiantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IdentificationEtudiantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IdentificationEtudiants
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.IdentificationEtudiants.Include(i => i.Etudiant).Include(i => i.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: IdentificationEtudiants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identificationEtudiant = await _context.IdentificationEtudiants
                .Include(i => i.Etudiant)
                .Include(i => i.IdentityUser)
                .FirstOrDefaultAsync(m => m.EtudiantId == id);
            if (identificationEtudiant == null)
            {
                return NotFound();
            }

            return View(identificationEtudiant);
        }

        // GET: IdentificationEtudiants/Create
        public IActionResult Create()
        {
            ViewData["EtudiantId"] = new SelectList(EtudiantsNotAlreadyListed(_context), "Id", "Fullname");
            ViewData["IdentityUserId"] = new SelectList(IdentityUsersNotAlreadyListed(_context), "Id", "UserName");
            return View();
        }

        // POST: IdentificationEtudiants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EtudiantId,IdentityUserId")] IdentificationEtudiant identificationEtudiant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(identificationEtudiant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EtudiantId"] = new SelectList(_context.Etudiants, "Id", "Fullname", identificationEtudiant.EtudiantId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "UserName", identificationEtudiant.IdentityUserId);
            return View(identificationEtudiant);
        }

        // GET: IdentificationEtudiants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identificationEtudiant = await _context.IdentificationEtudiants.FindAsync(id);
            if (identificationEtudiant == null)
            {
                return NotFound();
            }
            ViewData["EtudiantId"] = new SelectList(_context.Etudiants, "Id", "Fullname", identificationEtudiant.EtudiantId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "UserName", identificationEtudiant.IdentityUserId);
            return View(identificationEtudiant);
        }

        // POST: IdentificationEtudiants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EtudiantId,IdentityUserId")] IdentificationEtudiant identificationEtudiant)
        {
            if (id != identificationEtudiant.EtudiantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(identificationEtudiant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdentificationEtudiantExists(identificationEtudiant.EtudiantId))
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
            ViewData["EtudiantId"] = new SelectList(_context.Etudiants, "Id", "Fullname", identificationEtudiant.EtudiantId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "UserName", identificationEtudiant.IdentityUserId);
            return View(identificationEtudiant);
        }

        // GET: IdentificationEtudiants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identificationEtudiant = await _context.IdentificationEtudiants
                .Include(i => i.Etudiant)
                .Include(i => i.IdentityUser)
                .FirstOrDefaultAsync(m => m.EtudiantId == id);
            if (identificationEtudiant == null)
            {
                return NotFound();
            }

            return View(identificationEtudiant);
        }

        // POST: IdentificationEtudiants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var identificationEtudiant = await _context.IdentificationEtudiants.FindAsync(id);
            _context.IdentificationEtudiants.Remove(identificationEtudiant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdentificationEtudiantExists(int id)
        {
            return _context.IdentificationEtudiants.Any(e => e.EtudiantId == id);
        }
    }
}
