using BenTechAPI.Data;
using BenTechAPI.Models;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace BenTechAPI.Endpoints.DatesEnpoint.GetAllDaysWithPredefinedPrices
{
    public class GetAllDaysWithPredefinedPricesEndpoint : EndpointWithoutRequest<List<Dates>>
    {
        private readonly ApplicationDBContext _dbContext;

        public GetAllDaysWithPredefinedPricesEndpoint(ApplicationDBContext context)
        {

            _dbContext = context;
        }

        public override void Configure()
        {
            Get("api/daysWithPredefinedPrices");
            AllowAnonymous();
        }


        public override async Task HandleAsync(CancellationToken ct)
        {

            var dates = await _dbContext.Dates
                .Include(d => d.predefinedPrices)
                .ToListAsync(ct);


            var dayDtos = dates.Select(d => new DayDto
            {
                Date = d.Date,
                ColorCode = d.ColorCode,
                DoubleValue = d.predefinedPrices?.Double_value,
                SingleValue = d.predefinedPrices?.Single_value,
                TripleValue = d.predefinedPrices?.Triple_value,
                QuadrupleValue = d.predefinedPrices?.Quadruple_value,
                QuintupleValue = d.predefinedPrices?.Quintuple_value,
                Child03To06Value = d.predefinedPrices?.Child03To06_value,
                Child07To10Value = d.predefinedPrices?.Child07To10_value
            }).ToList();

            await SendAsync(dates, cancellation: ct);
        }

    }
}
