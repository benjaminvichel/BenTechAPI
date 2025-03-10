namespace BenTechAPI.Endpoints.DatesEnpoint.GetDatesInRange
{
    public class DateRangeRequest
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}