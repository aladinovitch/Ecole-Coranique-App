using System.ComponentModel.DataAnnotations;

namespace Ecole_Coranique.Models;
public class Groupe
{
    public int Id { get; set; }
    
    [Required]
    public int Numero { get; set; }
    [Required]
    public string Nom { get; set; }
    [Required]
    public int EnseignantId { get; set; }
    
    public Enseignant? Enseignant { get; set; }
    
    public ICollection<Etudiant>? GroupeEtudiants { get; set; }
}
