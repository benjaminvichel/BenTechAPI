using BenTechAPI.Data;
using FastEndpoints;
using FastEndpoints.AspVersioning;
using Microsoft.EntityFrameworkCore;

namespace BenTechAPI.Endpoints.PredefinedPrices.PricesPutEndpoint
{
    public class PricePutEndpoint : Endpoint<PricePutRequest, PricePutResponse>
    {
        private readonly ApplicationDBContext _dbContext;
        public PricePutEndpoint(ApplicationDBContext context)
        {

            _dbContext = context;
        }

        public override void Configure()
        {
            Options(o => o
            .WithVersionSet(">>Prices<<")
            .MapToApiVersion(1.0)
            );
            Put("api/price");
        }

        public override async Task HandleAsync(PricePutRequest req, CancellationToken ct)
        {
            var price = await _dbContext.PredefinedPrices.FirstOrDefaultAsync(p => p.ColorCode == req.ColorCode);

            if (price != null)
            {

                price.ColorCode = req.ColorCode;
                price.Name = req.Name;
                price.Double_value = req.Double_value;
                price.Single_value = req.Single_value;
                price.Triple_value = req.Triple_value;
                price.Quadruple_value = req.Quadruple_value;
                price.Quintuple_value = req.Quintuple_value;
                price.Child03To06_value = req.Child03To06_value;
                price.Child07To10_value = req.Child07To10_value;

                await _dbContext.SaveChangesAsync();

                await SendAsync(new()
                {
                    colorCode = req.ColorCode,
                    Message = "Values updated!!"
                });

                return;
            }

            await SendAsync(new()
            {
                colorCode = req.ColorCode,
                Message = "Price returned NULL"
            });
        }


    }

    public class PricePutResponse
    {
        public string colorCode { get; set; }
        public string? Message { get; set; }
    }

    public class PricePutRequest
    {
        public string ColorCode { get; set; }
        public string Name { get; set; }
        public double Double_value { get; set; }
        public double Single_value { get; set; }
        public double Triple_value { get; set; }
        public double Quadruple_value { get; set; }
        public double Quintuple_value { get; set; }
        public double Child03To06_value { get; set; }
        public double Child07To10_value { get; set; }
    }
}
