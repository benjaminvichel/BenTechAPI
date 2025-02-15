namespace BenTechAPI.Endpoints.DatesEnpoint.GetAllDaysWithPredefinedPrices
{
    public class DayDto
    {
        public DateTime Date { get; set; }
        public string ColorCode { get; set; }
        public double? DoubleValue { get; set; }
        public double? SingleValue { get; set; }
        public double? TripleValue { get; set; }
        public double? QuadrupleValue { get; set; }
        public double? QuintupleValue { get; set; }
        public double? Child03To06Value { get; set; }
        public double? Child07To10Value { get; set; }
    }
}