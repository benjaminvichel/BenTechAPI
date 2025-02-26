using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BenTechAPI.Models
{
    public class PredefinedPrices
    {
        [Key]
        [Column(TypeName = "varchar(10)")]
        public string ColorCode { get; set; }
        public string Name { get; set; }
        public double Double_value { get; set; }
        public double Single_value { get; set; }
        public double Triple_value { get; set; }
        public double Quadruple_value { get; set; }
        public double Quintuple_value { get; set; }
        public double Child03To06_value { get; set; }
        public double Child07To10_value { get; set; }

        public List<Dates>? Dates { get; set; }
    }
}
