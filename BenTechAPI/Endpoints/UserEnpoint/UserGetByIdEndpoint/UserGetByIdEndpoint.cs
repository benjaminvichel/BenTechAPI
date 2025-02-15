using BenTechAPI.Data;
using FastEndpoints;
using FastEndpoints.AspVersioning;
using Microsoft.OpenApi.Models;

namespace BenTechAPI.Endpoints.UserEnpoint.UserGetByIdEndpoint
{
    public class UserGetByIdEndpoint : Endpoint<UserGetIdRequest, UserGetIdResponse>
    {
        private readonly ApplicationDBContext _context;

        public UserGetByIdEndpoint(ApplicationDBContext context)
        {
            _context = context;
        }

        public override void Configure()
        {
            Options(x => x
           .WithVersionSet(">>User<<")
           .MapToApiVersion(1.0));
            Get("/api/users/{id}");
            AllowAnonymous();
            Summary(s =>
            {
                s.Summary = "Obtém um usuário pelo ID";
                s.Description = "Este endpoint retorna um usuário com base no ID fornecido na URL.";
                s.Params["id"] = "O ID do usuário para a consulta.";
            });
        }

        public override async Task HandleAsync(UserGetIdRequest req, CancellationToken ct)
        {
            var id = Route<Guid>("id");

            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            var response = new UserGetIdResponse
            {
                Name = user.User_name
            };

            await SendOkAsync(response, ct);
        }
    }
}
