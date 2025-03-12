using Azure.Core;
using BenTechAPI.Data;
using FastEndpoints;
using FastEndpoints.AspVersioning;
using Microsoft.EntityFrameworkCore;

namespace BenTechAPI.Endpoints.DatesEnpoint.GetDatesInRange
{
    public class GetDatesInRangeEndpoint : EndpointWithoutRequest<List<DateRangeResponse>>
    {
        private readonly ApplicationDBContext _dbContext;

        public GetDatesInRangeEndpoint(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void Configure()
        {
            Options(x => x
                .WithVersionSet(">>Dates<<")
                .MapToApiVersion(1.0));
            Get("api/datesInRange/{StartDate}/{EndDate}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var startDate = Route<DateOnly>("StartDate");
            var endDate = Route<DateOnly>("EndDate");

            var dates = await _dbContext.Dates.Include(d => d.PredefinedPrices)
                .Where(d => d.Date >= startDate && d.Date <= endDate)
                    .ToListAsync();

            List<DateRangeResponse> dateRangeResponse = dates.Select(d => new DateRangeResponse
            {
                Date = d.Date,
                ColorCode = d.ColorCode,
                DoubleValue = d.PredefinedPrices.Double_value,
                SingleValue = d.PredefinedPrices.Single_value,
                TripleValue = d.PredefinedPrices.Triple_value,
                QuadrupleValue= d.PredefinedPrices.Quadruple_value,
                QuintupleValue = d.PredefinedPrices .Quintuple_value,
                Child03To06Value=d.PredefinedPrices.Child03To06_value,
                Child07To10Value = d.PredefinedPrices.Child07To10_value,
               
            }).ToList();
            await SendAsync(dateRangeResponse, cancellation: ct);


        }
    }
}
