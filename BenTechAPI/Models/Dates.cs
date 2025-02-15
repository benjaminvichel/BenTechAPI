using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BenTechAPI.Models
{
    [Table("dates")]
    public class Dates
    {
        [Key]
        public DateTime Date { get; set; }
        [ForeignKey("ColorCode")]
        [Column(TypeName ="varchar(10)")]
        public string ColorCode { get;set; }

 
        public PredefinedPrices PredefinedPrices { get; set; }

    }
}
