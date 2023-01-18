using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication27.Models
{
    public class Exponat
    {
        public int ID { get; set; }

        [Display(Name = "Expozitii temporare")]
        public string DenumireExponat { get; set; }

        [Display(Name = "Locație-expoziții")]

        public string Locatie { get; set; }
        public ICollection<Institutie>? Institutii { get; set; }
    }
}
