using MediatR;
using POS.Application.DTO;
using POS.Domain.ValueObjects;

namespace POS.Application.Carts.Queries;

public record GetCart(UserId UserId) : IRequest<CartDto>;
