using MediatR;
using POS.Application.DTO;

namespace POS.Application.Items.Queries;
public record GetItem(int ItemID) : IRequest<ItemDto>;
