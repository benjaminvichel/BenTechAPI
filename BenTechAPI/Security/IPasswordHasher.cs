namespace BenTechAPI.Security
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPassword(string hashedPassword, string providePasswrod);
    }
}
