using System.ComponentModel.DataAnnotations;

namespace Ecole_Coranique.Models;
public class Etudiant
{
    public int Id { get; set; }
    
    [Required]
    [Display(Name = "الإسم")]
    public string Prenom { get; set; }
    [Required]
    [Display(Name = "اللقب")]
    public string Nom { get; set; }
    [Required]
    [Display(Name = "تاريخ الميلاد")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime Naissance { get; set; }
    [Required]
    [Display(Name = "الهاتف")]
    public string Phone { get; set; }
    [Display(Name = "البريد الإلكتروني")]
    public string Email { get; set; }
    [Required]
    [Display(Name = "العنوان")]
    public string Adresse { get; set; }
    [Required]
    [Display(Name = "المجموعة")]
    public int GroupeId { get; set; }
    [Display(Name = "المجموعة")]
    public Groupe? Groupe { get; set; }
    public IdentificationEtudiant? Identification { get; set; }
    public ICollection<Absence>? EtudiantAbsences { get; set; }
    public ICollection<Revision>? EtudiantRevisions { get; set; }
    public string Fullname => $"{Prenom}, {Nom}";
}
