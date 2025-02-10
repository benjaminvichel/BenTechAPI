using BenTechAPI.Data;
using BenTechAPI.Models;
using BenTechAPI.Security;
using FastEndpoints;
using Microsoft.AspNetCore.Identity;

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
            Post("/api/user/create");
            AllowAnonymous();
        }

        public override async Task HandleAsync(UserPostRequest req, CancellationToken ct)
        {
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
