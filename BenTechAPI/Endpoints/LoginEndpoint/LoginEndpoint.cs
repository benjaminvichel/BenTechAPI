using BenTechAPI.Data;
using BenTechAPI.Security;
using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.EntityFrameworkCore;

namespace BenTechAPI.Endpoints.LoginEndpoint
{
    public class LoginEndpoint : Endpoint<LoginRequest, LoginResponse>
    {

        private readonly ApplicationDBContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public LoginEndpoint(ApplicationDBContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public override void Configure()
        {

            Post("api/login");
            AllowAnonymous();
        }

        public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.User_name == req.Username,ct);

            if (user == null || !_passwordHasher.VerifyPassword(user.Password, req.Password))
            {
                ThrowError("Credenciais inválidas!");
            }

            var signingKey = Config["JwtSettings:SigningKey"];
            var jwtToken = JwtBearer.CreateToken(o =>
            {
                o.SigningKey = signingKey;
                o.ExpireAt = DateTime.UtcNow.AddHours(1); // A expiração do token
                o.User.Claims.Add(("UserName", req.Username)); // Adiciona o nome do usuário
                o.User["UserId"] = user.Id.ToString(); // Aqui é o ID real do usuário do banco de dados (Guid convertido para string)
                o.User["UserIsAdmin"] = user.IsAdmin.ToString();
            });

            await SendAsync(new LoginResponse
            {
                Username = req.Username,
                Token = jwtToken
            });


        }
    }

}

