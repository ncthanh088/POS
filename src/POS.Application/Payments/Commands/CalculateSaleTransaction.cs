using MediatR;

namespace POS.Application.Payments.Commands;

public class CalculateSaleTransaction : BaseSaleTransaction, IRequest<CalculateSaleTransaction>
{
    public CalculateSaleTransaction()
    {

    }
}
