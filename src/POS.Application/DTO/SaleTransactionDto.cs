using System.Linq.Expressions;

namespace POS.Application.DTO
{
    public class SaleTransactionDto
    {
        public long TransactionId { get; set; }
        public int TransactionNumber { get; set; }
        public long? SerialNumber { get; set; }
        public DateTime CreatedAt { get; set; }

        public static Expression<Func<Domain.Entities.SaleTransaction, SaleTransactionDto>> Expression
        {
            get
            {
                return transaction => new SaleTransactionDto
                {
                    TransactionId = transaction.Id,
                    TransactionNumber = transaction.TransactionNumber,
                    SerialNumber = transaction.SerialNumber,
                    CreatedAt = transaction.CreatedAt,
                };
            }
        }

        public static SaleTransactionDto Parse(Domain.Entities.SaleTransaction transaction)
        {
            if (transaction == null)
            {
                return null;
            }
            return Expression.Compile().Invoke(transaction);
        }
    }
}
