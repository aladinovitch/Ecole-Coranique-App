using System.ComponentModel.DataAnnotations;

namespace Ecole_Coranique.Models;
public class Enseignant
{
    public int Id { get; set; }
    
    [Required]
    [Display(Name = "الإسم")]
    public string Prenom { get; set; }
    [Required]
    [Display(Name = "اللقب")]
    public string Nom { get; set; }
    [Required]
    [Display(Name = "الهاتف")]
    public string Phone { get; set; }
    [Required]
    [Display(Name = "البريد الإلكتروني")]
    public string Email { get; set; }
    [Required]
    [Display(Name = "العنوان")]
    public string Adresse { get; set; }
    public ICollection<Groupe>? EnseignantGroupes { get; set; }
    public IdentificationEnseignant? Identification { get; set; }
    public string Fullname => $"{Prenom}, {Nom}";
}
