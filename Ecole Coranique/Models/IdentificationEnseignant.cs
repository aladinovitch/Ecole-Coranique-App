using Ecole_Coranique.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace Ecole_Coranique.Models;
public class IdentificationEnseignant
{
    [Required]
    [Display(Name = "المدرس")]
    public int EnseignantId { get; set; }
    [Required]
    [Display(Name = "المستعمل في البرنامج")]
    public string IdentityUserId { get; set; }
    public Enseignant? Enseignant { get; set; }
    public IdentityUser? IdentityUser { get; set; }
}
