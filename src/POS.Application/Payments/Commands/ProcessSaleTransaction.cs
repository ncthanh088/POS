using MediatR;
using POS.Application.DTO;

namespace POS.Application.Payments.Commands;

public class ProcessSaleTransaction : BaseSaleTransaction, IRequest<ProcessSaleTransactionDto>
{
    public ProcessSaleTransaction()
    {

    }
}
