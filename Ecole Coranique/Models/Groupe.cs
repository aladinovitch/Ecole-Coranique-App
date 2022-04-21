using System.ComponentModel.DataAnnotations;

namespace Ecole_Coranique.Models;
public class Groupe
{
    public int Id { get; set; }
    
    [Required]
    [Display(Name = "الرقم")]
    public int Numero { get; set; }
    [Required]
    [Display(Name = "الإسم")]
    public string Nom { get; set; }
    [Required]
    [Display(Name = "المدرس")]
    public int EnseignantId { get; set; }
    [Display(Name = "المدرس")]
    public Enseignant? Enseignant { get; set; }
    
    public ICollection<Etudiant>? GroupeEtudiants { get; set; }
}
