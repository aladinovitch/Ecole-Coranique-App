using System.ComponentModel.DataAnnotations;

namespace Ecole_Coranique.Models;
public class Revision
{
    public int Id { get; set; }
    
    [Required]
    [Display(Name = "التاريخ")]
    [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
    public DateTime Date { get; set; }
    [Required]
    [Display(Name = "الطالب")]
    public int EtudiantId { get; set; }
    [Required]
    [Display(Name = "الحزب")]
    public int HizbId { get; set; }
    [Required]
    [Display(Name = "الثمن")]
    public int HuitiemeId { get; set; }
    [Display(Name = "الطالب")]
    public Etudiant? Etudiant { get; set; }
    [Display(Name = "الحزب")]
    public Hizb? Hizb { get; set; }
    [Display(Name = "الثمن")]
    public Huitieme? Huitieme { get; set; }
}
