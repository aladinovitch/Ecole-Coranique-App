using System.ComponentModel.DataAnnotations;

namespace Ecole_Coranique.Models;
public class Huitieme
{
    public int Id { get; set; }
    
    [Required]
    [Display(Name = "الرقم")]
    public int Numero { get; set; }
    [Display(Name = "الإسم")]
    public string Nom { get; set; }
    
    public ICollection<Revision>? HuitiemeRevisions { get; set; }
}
