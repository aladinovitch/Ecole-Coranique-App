using System.ComponentModel.DataAnnotations;

namespace Ecole_Coranique.Models;
public class Absence
{
    public int Id { get; set; }
    
    [Required]
    [Display(Name = "التاريخ")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime Date { get; set; }
    [Display(Name = "الملاحظة")]
    public string Observation { get; set; }
    [Required]
    [Display(Name = "الطالب")]
    public int EtudiantId { get; set; }
    [Display(Name = "الطالب")]
    public Etudiant? Etudiant { get; set; }
}
