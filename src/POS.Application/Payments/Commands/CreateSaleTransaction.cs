using MediatR;
using POS.Application.DTO;

namespace POS.Application.Payments.Commands
{
    public class CreateSaleTransaction : IRequest<SaleTransactionDto>
    {
        public int UserId { get; set; }
        public int? MemberId { get; set; }
        public string TransactionType { get; set; }
    }
}
