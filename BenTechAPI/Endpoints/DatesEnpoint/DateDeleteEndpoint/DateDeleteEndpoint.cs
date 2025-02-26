using BenTechAPI.Data;
using FastEndpoints;
using FastEndpoints.AspVersioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BenTechAPI.Endpoints.DatesEnpoint.DateDeleteEndpoint
{
    public class DateDeleteEndpoint : EndpointWithoutRequest
    {
        private readonly ApplicationDBContext _dbContext;
        public DateDeleteEndpoint(ApplicationDBContext context)
        {

            _dbContext = context;

        }


        public override void Configure()
        {
            Options(o => o
            .WithVersionSet(">>Dates<<")
            .MapToApiVersion(1.0)
            );
            Delete("api/date/{date}");
        }


        public override async Task HandleAsync(CancellationToken ct)
        {
            var date = Route<DateOnly>("date");

            var dateExist = await _dbContext.Dates.FirstOrDefaultAsync(d => d.Date == date);

            if (dateExist != null)
            {
                _dbContext.Remove(dateExist);
                await _dbContext.SaveChangesAsync();
                return;
            }

            await SendNoContentAsync();
        }
    }
}
