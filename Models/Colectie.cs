using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication27.Models
{
    public class Colectie
    {
        public int ID { get; set; }


        [Display(Name = "Colecții permanente")]
        public string? NumeleColectiilor { get; set; }
        public ICollection<Institutie>? Institutii { get; set; } //navigation property
    }
}
