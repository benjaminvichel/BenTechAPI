using BenTechAPI.Data;
using BenTechAPI.Endpoints.DatesEnpoint.UpdateDayEndpoint;
using FastEndpoints;
using FastEndpoints.AspVersioning;
using Microsoft.EntityFrameworkCore;

namespace BenTechAPI.Endpoints.UserEnpoint.UserUpdateEndpoint
{
    public class UserUpdateEndpoint : Endpoint<UpdateUser, UpdateUserResponse>
    {
        private readonly ApplicationDBContext _dbContext;
        public UserUpdateEndpoint(ApplicationDBContext context)
        {
            _dbContext = context;
        }

        public override void Configure()
        {
            Options(x => x
           .WithVersionSet(">>User<<")
           .MapToApiVersion(1.0));
            Put("api/user");
            AllowAnonymous();
        }

        public override async Task HandleAsync(UpdateUser req, CancellationToken ct)
        {

            var user = await _dbContext.User.FirstOrDefaultAsync(u => u.Id == req.Id);


            if (user != null)
            {

                user.User_name = req.UserName;
                user.IsAdmin = req.IsAdmin;


                await _dbContext.SaveChangesAsync();
            }
            else
            {

                var errorResponse = new UpdateUserResponse
                {
                    Message = "User was NULL!"
                };

                await SendAsync(errorResponse, statusCode: 400, cancellation: ct);
            }
        }

    }
}
