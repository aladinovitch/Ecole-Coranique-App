using Ecole_Coranique.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecole_Coranique.Controllers
{
    public class TrackingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrackingController(ApplicationDbContext context) {
            _context = context;
        }
        public async Task<IActionResult> AdminTrack() {
            return View(await _context.Enseignants.ToListAsync());
        }
        public async Task<IActionResult> TeacherTrack(int? id) {
            if (id == null) {
                return NotFound();
            }
            var enseignant = await _context.Enseignants
                .Include(x => x.EnseignantGroupes)
                .ThenInclude(x => x.GroupeEtudiants)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (enseignant == null) {
                return NotFound();
            }
            return View(enseignant);
        }
        public async Task<IActionResult> StudentTrack(int? id) {
            if (id == null) {
                return NotFound();
            }
            var etudiant = await _context.Etudiants
                .Include(e => e.Groupe)
                .Include(e => e.EtudiantAbsences)
                .Include(e => e.EtudiantRevisions)
                .ThenInclude(r => r.Hizb)
                .Include(e => e.EtudiantRevisions)
                .ThenInclude(r => r.Huitieme)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (etudiant == null) {
                return NotFound();
            }
            return View(etudiant);
        }
    }
}
