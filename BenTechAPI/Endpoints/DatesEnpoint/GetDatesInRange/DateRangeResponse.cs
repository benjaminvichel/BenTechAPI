using System.ComponentModel.DataAnnotations.Schema;

namespace BenTechAPI.Endpoints.DatesEnpoint.GetDatesInRange
{
    public class DateRangeResponse
    {
        public DateOnly Date { get; set; }
        public string ColorCode { get; set; }
    }
}