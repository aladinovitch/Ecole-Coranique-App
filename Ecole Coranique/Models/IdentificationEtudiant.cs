using Ecole_Coranique.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace Ecole_Coranique.Models;
public class IdentificationEtudiant
{
    [Required]
    [Display(Name = "الطالب")]
    public int EtudiantId { get; set; }
    [Required]
    [Display(Name = "المستعمل في البرنامج")]
    public string IdentityUserId { get; set; }
    public Etudiant? Etudiant { get; set; }
    public IdentityUser? IdentityUser { get; set; }
}
