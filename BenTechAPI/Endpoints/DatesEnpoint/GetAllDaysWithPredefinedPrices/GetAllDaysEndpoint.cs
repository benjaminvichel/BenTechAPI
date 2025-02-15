using BenTechAPI.Data;
using BenTechAPI.Models;
using FastEndpoints;
using FastEndpoints.AspVersioning;
using Microsoft.EntityFrameworkCore;

namespace BenTechAPI.Endpoints.DatesEnpoint.GetAllDaysWithPredefinedPrices
{
    public class GetAllDaysWithPredefinedPricesEndpoint : EndpointWithoutRequest<List<DayDto>>
    {
        private readonly ApplicationDBContext _dbContext;

        public GetAllDaysWithPredefinedPricesEndpoint(ApplicationDBContext context)
        {

            _dbContext = context;
        }

        public override void Configure()
        {
            Options(x => x
           .WithVersionSet(">>Dates<<")
           .MapToApiVersion(1.0));
            Get("api/dateWithPredefinedPrices");
            AllowAnonymous();
        }


        public override async Task HandleAsync(CancellationToken ct)
        {

            var dates = await _dbContext.Dates
                .Include(d => d.PredefinedPrices)
                .ToListAsync(ct);


            var dayDtos = dates.Select(d => new DayDto
            {
                Date = d.Date,
                ColorCode = d.ColorCode,
                DoubleValue = d.PredefinedPrices?.Double_value,
                SingleValue = d.PredefinedPrices?.Single_value,
                TripleValue = d.PredefinedPrices?.Triple_value,
                QuadrupleValue = d.PredefinedPrices?.Quadruple_value,
                QuintupleValue = d.PredefinedPrices?.Quintuple_value,
                Child03To06Value = d.PredefinedPrices?.Child03To06_value,
                Child07To10Value = d.PredefinedPrices?.Child07To10_value
            }).ToList();

            await SendAsync(dayDtos, cancellation: ct);
        }

    }
}
