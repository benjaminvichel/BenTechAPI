namespace BenTechAPI.Endpoints.PredefinedPrices.PricesGetAll
{
    using BenTechAPI.Data;
    using BenTechAPI.Models;
    using FastEndpoints;
    using FastEndpoints.AspVersioning;
    using Microsoft.EntityFrameworkCore;

    public class PredefinedPricesGetAll : EndpointWithoutRequest<List<PredefinedPricesDto>>
    {
        private readonly ApplicationDBContext _dbContext;
        public PredefinedPricesGetAll(ApplicationDBContext context)
        {
            _dbContext = context;
        }

        public override void Configure()
        {
            Options(x => x
            .WithVersionSet(">>Prices<<")
            .MapToApiVersion(1.0));
            Get("api/v1/prices");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {

            var prices = await _dbContext.PredefinedPrices
                .Include(p => p.Dates)
                .ToListAsync(ct);
            
            var pricesDto = prices.Select(p => new PredefinedPricesDto
            {
                ColorCode = p.ColorCode,
                Double_value = p.Double_value,
                Single_value = p.Single_value,
                Triple_value = p.Triple_value,
                Quadruple_value = p.Quadruple_value,
                Quintuple_value = p.Quintuple_value,
                Child03To06_value = p.Child03To06_value,
                Child07To10_value = p.Child07To10_value,
                Dates = p.Dates?.Select(d => new DateDto { Date = d.Date }).ToList()
            }).ToList();

            await SendAsync(pricesDto, cancellation: ct);

        }
    }

   public class PredefinedPricesDto
{
    public string ColorCode { get; set; }
    public double Double_value { get; set; }
    public double Single_value { get; set; }
    public double Triple_value { get; set; }
    public double Quadruple_value { get; set; }
    public double Quintuple_value { get; set; }
    public double Child03To06_value { get; set; }
    public double Child07To10_value { get; set; }
    public List<DateDto>? Dates { get; set; }
}

public class DateDto
{
    public DateTime Date { get; set; }
}
}
