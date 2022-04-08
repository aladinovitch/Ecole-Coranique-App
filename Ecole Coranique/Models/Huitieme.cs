using System.ComponentModel.DataAnnotations;

namespace Ecole_Coranique.Models;
public class Huitieme
{
    public int Id { get; set; }
    
    [Required]
    public int Numero { get; set; }
    public string Nom { get; set; }
    
    public ICollection<Revision>? HuitiemeRevisions { get; set; }
}
