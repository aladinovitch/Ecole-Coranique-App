using System.ComponentModel.DataAnnotations;

namespace Ecole_Coranique.Models;
public class Hizb
{
    public int Id { get; set; }
    
    [Required]
    [Display(Name = "الرقم")]
    public int Numero { get; set; }
    [Display(Name = "الإسم")]
    public string Nom { get; set; }
    [Display(Name = "التفصيل")]
    public string Description { get; set; }

    public ICollection<Revision>? HizbRevisions { get; set; }
}
