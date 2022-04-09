using System.ComponentModel.DataAnnotations;

namespace Ecole_Coranique.Models;
public class Hizb
{
    public int Id { get; set; }
    
    [Required]
    public int Numero { get; set; }
    public string Nom { get; set; }
    public string Description { get; set; }

    public ICollection<Revision>? HizbRevisions { get; set; }
}
