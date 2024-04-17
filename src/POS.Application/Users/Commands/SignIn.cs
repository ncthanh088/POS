using MediatR;

namespace POS.Application.Users.Commands;

public record SignIn(string Email, string Password) : IRequest;
