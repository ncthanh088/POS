using Microsoft.AspNetCore.Identity;
using POS.Application.Security;
using POS.Domain.Entities;

namespace POS.Infrastructure.Security;

internal sealed class PasswordManager : IPasswordManager
{
    private readonly IPasswordHasher<User> _passwordHasher;

    public PasswordManager(IPasswordHasher<User> passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public string Secure(string password) => _passwordHasher.HashPassword(default, password);

    public bool Validate(string password, string securedPassword)
        => _passwordHasher.VerifyHashedPassword(default, securedPassword, password) ==
           PasswordVerificationResult.Success;
}
