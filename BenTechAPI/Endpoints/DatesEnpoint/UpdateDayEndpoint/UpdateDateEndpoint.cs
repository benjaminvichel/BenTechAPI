using BenTechAPI.Data;
using FastEndpoints;
using FastEndpoints.AspVersioning;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BenTechAPI.Endpoints.DatesEnpoint.UpdateDayEndpoint
{
    public class UpdateDateEndpoint : Endpoint<UpdateRequest, UpdateDateResponse>
    {
        private readonly ApplicationDBContext _dbContext;

        public UpdateDateEndpoint(ApplicationDBContext context)
        {
            _dbContext = context;
        }
        public override void Configure()
        {
            Options(x => x
            .WithVersionSet(">>Dates<<")
            .MapToApiVersion(1.0));
            Put("api/date");
        }
        public override async Task HandleAsync(UpdateRequest req, CancellationToken ct)
        {
         
            var day = await _dbContext.Dates.FirstOrDefaultAsync(d => d.Date == req.Date, ct);
            if (day != null)
            {
                day.ColorCode = req.colorCode;
                await _dbContext.SaveChangesAsync();

            }
            else
            {
                var errorResponse = new UpdateDateResponse
                {
                    Message = "Day was NULL!"
                };

                await SendAsync(errorResponse, statusCode: 400, cancellation: ct);
            }
        }
    }
}
