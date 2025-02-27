using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;

namespace CuriosityApi.Services.Password;

public class PasswordService : IPasswordService
{
    readonly PasswordHasher<string> hasher = new();
    public string Hash(string password)
    => hasher.HashPassword(password, password);

    public bool Compare(string password, string hashedPassword)
    {
        var hash = hasher.VerifyHashedPassword(password, hashedPassword, password);
        return hash == PasswordVerificationResult.Success;
    }

}