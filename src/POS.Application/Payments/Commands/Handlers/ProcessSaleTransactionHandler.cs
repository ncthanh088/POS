using MediatR;
using POS.Application.DTO;

namespace POS.Application.Payments.Commands.Handlers;

public class ProcessSaleTransactionHandler : IRequestHandler<ProcessSaleTransaction, ProcessSaleTransactionDto>
{
    public Task<ProcessSaleTransactionDto> Handle(ProcessSaleTransaction request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
