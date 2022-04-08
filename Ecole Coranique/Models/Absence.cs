using System.ComponentModel.DataAnnotations;

namespace Ecole_Coranique.Models;
public class Absence
{
    public int Id { get; set; }
    
    [Required]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime Date { get; set; }
    public string Observation { get; set; }
    [Required]
    public int EtudiantId { get; set; }
    
    public Etudiant? Etudiant { get; set; }
}
