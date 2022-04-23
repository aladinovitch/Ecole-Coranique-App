using Ecole_Coranique.Data;
using Ecole_Coranique.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace Ecole_Coranique.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context) {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> IndexAsync() {
            //var idCurrentUser = _context.Users.Where(x => !_context.IdentificationEtudiants.Select(x => x.IdentityUserId).Contains(x.Id));
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var authService = HttpContext.RequestServices.GetRequiredService<IAuthorizationService>();
            if ((await authService.AuthorizeAsync(User, AppPolicyName.Administration)).Succeeded) {
                return View();
            } else if ((await authService.AuthorizeAsync(User, AppPolicyName.TeacherTrack)).Succeeded) {
                return RedirectToAction("TeacherTrack", "Tracking", new { Id = 1 });
            } else if ((await authService.AuthorizeAsync(User, AppPolicyName.StudentTrack)).Succeeded) {
                var idCurrentStudent = await _context.IdentificationEtudiants
                .Where(x => x.IdentityUserId.Equals(currentUserId)).Select(x => x.EtudiantId).FirstOrDefaultAsync();
                return RedirectToAction("StudentTrack", "Tracking", new { Id = idCurrentStudent });
            }
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}