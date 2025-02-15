using BenTechAPI.Data;
using BenTechAPI.Models;
using FastEndpoints;
using FastEndpoints.AspVersioning;

namespace BenTechAPI.Endpoints.DatesEnpoint.Day_PredefinedPricesPostEnspoint
{
    public class DayAndPredefinedPricesPostEndpoint : Endpoint<DayAndPriceRequest, DayAndPriceResponse>
    {
        private readonly ApplicationDBContext _dbContext;
        public DayAndPredefinedPricesPostEndpoint(ApplicationDBContext context)
        {
            _dbContext = context;
        }
        public override void Configure()
        {
            Options(x => x
           .WithVersionSet(">>Dates<<")
           .MapToApiVersion(1.0));
            Post("api/date");
            AllowAnonymous();
        }

        public override async Task HandleAsync(DayAndPriceRequest req, CancellationToken ct)
        {

            var day = new Dates
            {
                Date = req.Date,
                ColorCode = req.ColorCode,
            };

            _dbContext.Add(day);
            await _dbContext.SaveChangesAsync();

            await SendAsync(new()
            {
                Date = req.Date,
                ColorCode = req.ColorCode
            }, cancellation: ct);
        }
    }

    public class DayAndPriceResponse
    {
        public DateTime Date { get; set; }
        public string ColorCode { get; set; }
    }

    public class DayAndPriceRequest
    {
        public DateTime Date { get; set; }
        public string ColorCode { get; set; }
    }
}
