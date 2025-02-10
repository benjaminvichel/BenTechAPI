using Microsoft.AspNetCore.Identity;

namespace BenTechAPI.Security
{
    public class PasswordHasherService : IPasswordHasher
    {
        private readonly PasswordHasher<string> _passwordHasher = new();
        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null,password);
        }

        public bool VerifyPassword(string hashedPassword, string providePasswrod)
        {
        return _passwordHasher.VerifyHashedPassword(null,hashedPassword,providePasswrod) == PasswordVerificationResult.Success;
        }
    }
}
