using System.ComponentModel.DataAnnotations;

namespace Ecole_Coranique.Models;
public class Etudiant
{
    public int Id { get; set; }
    
    [Required]
    public string Prenom { get; set; }
    [Required]
    public string Nom { get; set; }
    [Required]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime Naissance { get; set; }
    [Required]
    public string Phone { get; set; }
    public string Email { get; set; }
    [Required]
    public string Adresse { get; set; }
    [Required]
    public int GroupeId { get; set; }
    
    public Groupe? Groupe { get; set; }
    
    public ICollection<Absence>? EtudiantAbsences { get; set; }
    public ICollection<Revision>? EtudiantRevisions { get; set; }
}
