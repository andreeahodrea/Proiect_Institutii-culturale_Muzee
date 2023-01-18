using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace WebApplication27.Models
{
    public class Institutie
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Program { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Bilet { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data publicării")]
        public DateTime PublishingDate { get; set; }
        public int? ColectieID { get; set; }
        public Colectie? Colectie { get; set; }

        public int? ExponatID { get; set; }
        public Exponat? Exponat { get; set; }
    } //navigation property
}
   

