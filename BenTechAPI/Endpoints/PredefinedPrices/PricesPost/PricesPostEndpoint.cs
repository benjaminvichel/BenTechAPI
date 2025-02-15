using BenTechAPI.Data;
using FastEndpoints;
using FastEndpoints.AspVersioning;
using Microsoft.EntityFrameworkCore;

namespace BenTechAPI.Endpoints.PredefinedPrices.PricesPost
{
    public class PricesPostEndpoint : Endpoint<PricesPostRequest, PricesPostResponse>
    {
        private readonly ApplicationDBContext _dbContext;
        public PricesPostEndpoint(ApplicationDBContext context)
        {
            _dbContext = context;
        }

        public override void Configure()
        {
            Options(x => x
            .WithVersionSet(">>Prices<<")
            .MapToApiVersion(1.0)
            );
            Post("api/prices");
            AllowAnonymous();
        }


        public override async Task HandleAsync(PricesPostRequest req, CancellationToken ct)
        {

            var priceAlreadyExist = await _dbContext.PredefinedPrices.FirstOrDefaultAsync(p => p.ColorCode == req.ColorCode);
            if (priceAlreadyExist != null)
            {
                var errorMessage = new PricesPostResponse
                {
                    ColorCode = req.ColorCode,
                    Message = "Color Already Exist!"
                };

                await SendAsync(errorMessage, cancellation: ct);
                return;
            }

            var price = new BenTechAPI.Models.PredefinedPrices
            {
                ColorCode = req.ColorCode,
                Double_value = req.Double_value,
                Single_value = req.Single_value,
                Triple_value = req.Triple_value,
                Quadruple_value = req.Quadruple_value,
                Quintuple_value = req.Quintuple_value,
                Child03To06_value = req.Child03To06_value,
                Child07To10_value = req.Child07To10_value,
            };
            _dbContext.PredefinedPrices.Add(price);
            await _dbContext.SaveChangesAsync(ct);

            await SendAsync(new()
            {
                ColorCode = req.ColorCode,
                Message = "PredefinedPrice Added!"
            }, cancellation: ct);
        }
    }

    public class PricesPostResponse
    {
        public string ColorCode { get; set; }
        public string? Message { get; set; }
    }

    public class PricesPostRequest
    {
        public string ColorCode { get; set; }
        public double Double_value { get; set; }
        public double Single_value { get; set; }
        public double Triple_value { get; set; }
        public double Quadruple_value { get; set; }
        public double Quintuple_value { get; set; }
        public double Child03To06_value { get; set; }
        public double Child07To10_value { get; set; }
    }
}
