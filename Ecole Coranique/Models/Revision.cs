using System.ComponentModel.DataAnnotations;

namespace Ecole_Coranique.Models;
public class Revision
{
    public int Id { get; set; }
    
    [Required]
    [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
    public DateTime Date { get; set; }
    [Required]
    public int EtudiantId { get; set; }
    [Required]
    public int HizbId { get; set; }
    [Required]
    public int HuitiemeId { get; set; }
    
    public Huitieme? Huitieme { get; set; }
    public Etudiant? Etudiant { get; set; }
    public Hizb? Hizb { get; set; }
}
