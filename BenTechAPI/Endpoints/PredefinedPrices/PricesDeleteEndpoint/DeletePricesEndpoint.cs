using BenTechAPI.Data;
using BenTechAPI.Models;
using FastEndpoints;
using FastEndpoints.AspVersioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BenTechAPI.Endpoints.PredefinedPrices.PredefinedPricesDeleteEndpoint
{
    public class DeletePricesEndpoint : EndpointWithoutRequest
    {
        private readonly ApplicationDBContext _context;
        public DeletePricesEndpoint(ApplicationDBContext context)
        {

            _context = context;


        }
        public override void Configure()
        {
            Options(x => x
            .WithVersionSet(">>Prices<<")
            .MapToApiVersion(1.0)
            );
            Delete("api/prices/{colorCode}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {

            var colorCode = Route<string>("colorCode");

            colorCode = "#" + colorCode;

            var price = await _context.PredefinedPrices.FindAsync(colorCode, ct);

            if (price == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }
            _context.PredefinedPrices.Remove(price);

            await _context.SaveChangesAsync();
        }


    }
}
