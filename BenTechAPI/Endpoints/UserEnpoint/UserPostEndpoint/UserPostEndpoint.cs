using BenTechAPI.Data;
using BenTechAPI.Models;
using BenTechAPI.Security;
using FastEndpoints;
using FastEndpoints.AspVersioning;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BenTechAPI.Endpoints.UserEnpoint.UserPostEndpoint
{
    public class UserPostEndpoint : Endpoint<UserPostRequest, UserPostResponse>
    {
        private readonly ApplicationDBContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public UserPostEndpoint(ApplicationDBContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public override void Configure()
        {
            Options(x => x
           .WithVersionSet(">>User<<")
           .MapToApiVersion(1.0));
            Post("/api/user/create");
        }

        public override async Task HandleAsync(UserPostRequest req, CancellationToken ct)
        {
            var existingUser = await _context.User
                .FirstOrDefaultAsync(u => u.User_name == req.FirstName, ct);
            if (existingUser != null)
            {
                var errorResponse = new UserPostResponse
                {
                    FullName = req.FirstName,
                    IsAdmin = req.IsAdmin,
                    ErrorMessage = "Nome de usuário já está em uso."
                };

                await SendAsync(errorResponse, statusCode: 400, cancellation: ct);
                return;
            }
            string hashedPassword = _passwordHasher.HashPassword(req.Password);

            var user = new User
            {
                Id = Guid.NewGuid(),
                User_name = req.FirstName,
                Password = hashedPassword,
                IsAdmin = req.IsAdmin
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync(ct);


            await SendAsync(new()
            {
                FullName = req.FirstName,
                IsAdmin = req.IsAdmin
            }, cancellation: ct);
        }
    }
}

