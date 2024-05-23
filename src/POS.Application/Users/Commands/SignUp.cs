using MediatR;

namespace POS.Application.Users.Commands;

public record SignUp(string Email, string Username, string Password, string FullName, string Role) : IRequest;
