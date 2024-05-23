using MediatR;
using POS.Domain.Enums;
using POS.Domain.Entities;
using POS.Application.DTO;
using POS.Application.Services;
using POS.Application.Repositories;

namespace POS.Application.Payments.Commands.Handlers;

public class ProcessSaleTransactionHandler : IRequestHandler<ProcessSaleTransaction, ProcessSaleTransactionDto>
{
    private readonly ILineItemRepository _lineItemRepository;

    public ProcessSaleTransactionHandler(IPaymentService paymentService, ILineItemRepository lineItemRepository)
    {
        _lineItemRepository = lineItemRepository;
    }

    public async Task<ProcessSaleTransactionDto> Handle(ProcessSaleTransaction request, CancellationToken cancellationToken)
    {
        var transactionId = request.TransactionId;

        await AddSaleLineItemsAsync(transactionId, request.Items);


        if (request.Taxes != null)
        {
            await AddTaxLineItemsAsync(transactionId, taxes: request.Taxes);
        }

        await AddTenderLineItemsAsync(transactionId, request.Tenders);

        return new ProcessSaleTransactionDto
        {

            Id = request.TransactionId,
            UserId = request.UserId,
            TotalExcludingTax = request.TotalExcludingTax,
            TaxTotal = request.TaxTotal,
            Total = request.Total,
            TenderRemainingTotal = request.TenderRemainingTotal,
            ChangeAmount = request.ChangeAmount,
            RoundedAmount = request.RoundedAmount,
            Taxes = request.Taxes,
            Items = request.Items,
            Tenders = request.Tenders,
            TransactionId = request.TransactionId,
            SerialNumber = request.SerialNumber,
            TransactionNumber = request.TransactionNumber,
            TransactionReferenceNumber = request.TransactionReferenceNumber,
            TransactionSerialNumber = request.TransactionSerialNumber,
            OpenCashDrawer = request.Tenders.Any(x => x.Type == TenderType.Cash),
            IsComplete = request.TenderTotal >= request.Total,
            CustomerId = request.CustomerId,
            WorkstationId = request.WorkstationId
        };
    }

    private async Task AddSaleLineItemsAsync(long transactionId, IEnumerable<TransactionItem> items)
    {
        foreach (var item in items)
        {
            var saleLineItem = new SaleLineItem
            {
                TransactionId = transactionId,
                SequenceNumber = item.SequenceNumber,
                ItemId = item.ItemId,
                TaxId = item.Tax.Id,
                TaxAmount = item.TotalTax,
                RegularUnitPrice = item.RegularUnitPrice,
                ActualUnitPrice = item.ActualUnitPrice,
                Quantity = item.Quantity,
                ExtendedPrice = item.TotalPrice,
                BeforeDiscountUnitPrice = item.BeforeDiscountUnitPrice,
                DiscountId = item.Discount?.Id,
            };
            await _lineItemRepository.CreateSaleLineItemAsync(saleLineItem);
        }
    }

    private async Task AddTaxLineItemsAsync(long transactionId, IEnumerable<TransactionTax> taxes)
    {
        foreach (var tax in taxes)
        {
            var taxLineItem = new TaxLineItem
            {
                TransactionId = transactionId,
                TaxId = tax.Id,
                TaxAmount = tax.Amount,
                TaxableAmount = tax.TaxableAmount
            };
            await _lineItemRepository.CreateTaxLineItemAsync(taxLineItem);
        }
    }

    private async Task AddTenderLineItemsAsync(long transactionId, IEnumerable<TransactionTender> tenders)
    {
        foreach (var tender in tenders)
        {
            var tenderLineItem = new TenderLineItem
            {
                SequenceNumber = tender.SequenceNumber,
                TransactionId = transactionId,
                TenderType = tender.Type,
                Amount = tender.Amount,
                IsVoid = false,
            };
            await _lineItemRepository.CreateTenderLineItemAsync(tenderLineItem);
        }
    }
}
