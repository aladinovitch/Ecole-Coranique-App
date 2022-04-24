using Ecole_Coranique.Data;
using Ecole_Coranique.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using static Ecole_Coranique.Helpers.Helpers;

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
            var authService = HttpContext.RequestServices.GetRequiredService<IAuthorizationService>();
            if ((await authService.AuthorizeAsync(User, AppPolicyName.Administration)).Succeeded) {
                return View();
            } else if ((await authService.AuthorizeAsync(User, AppPolicyName.TeacherTrack)).Succeeded) {
                var id = CurrentTeacherId(_context, User);
                if (id == 0) {
                    return NotFound();
                }
                return RedirectToAction("TeacherTrack", "Tracking", new { Id = id });
            } else if ((await authService.AuthorizeAsync(User, AppPolicyName.StudentTrack)).Succeeded) {
                var id = CurrentStudentId(_context, User);
                if (id == 0) {
                    return NotFound();
                }
                return RedirectToAction("StudentTrack", "Tracking", new { Id = id });
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