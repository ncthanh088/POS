using MediatR;
using POS.Application.DTO;
using POS.Domain.Entities;
using POS.Application.Repositories;

namespace POS.Application.Payments.Commands.Handlers
{
    public class CreateSaleTransactionHandler : IRequestHandler<CreateSaleTransaction, SaleTransactionDto>
    {
        private readonly ISaleTransactionRepository _transactionRepository;

        public CreateSaleTransactionHandler(ISaleTransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<SaleTransactionDto> Handle(CreateSaleTransaction request, CancellationToken cancellationToken)
        {
            var transaction = new SaleTransaction
            {
                UserId = request.UserId,
                CreatedAt = DateTime.UtcNow,
                SerialNumber = null, // TODO: Add Serial Number
                TransactionNumber = 0, // TODO: Add Transaction Number
            };
            return await _transactionRepository.CreateSaleTransaction(transaction);
        }
    }
}
