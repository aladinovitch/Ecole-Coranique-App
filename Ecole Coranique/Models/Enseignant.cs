using System.ComponentModel.DataAnnotations;

namespace Ecole_Coranique.Models;
public class Enseignant
{
    public int Id { get; set; }
    
    [Required]
    public string Prenom { get; set; }
    [Required]
    public string Nom { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Adresse { get; set; }
    
    public ICollection<Groupe>? EnseignantGroupes { get; set; }
}
