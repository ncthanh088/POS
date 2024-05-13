using MediatR;
using POS.Application.DTO;
using POS.Application.Repositories;
using POS.Domain.Entities;

namespace POS.Application.Payments.Commands.Handlers;

public class CalculateSaleTransactionHandler : IRequestHandler<CalculateSaleTransaction, CalculateSaleTransaction>
{
    private readonly ITaxRepository _taxRepository;
    private readonly IItemRepository _itemRepository;


    public async Task<CalculateSaleTransaction> Handle(CalculateSaleTransaction request, CancellationToken cancellationToken)
    {
        // Calculate tax
        await CalculateTaxAmountAsync(request.Items);
        // Calculate discount
        // Calculate item-price
        // Calculate total
        // Calculate tender
        // Calculate change
        // Rounding
        // Customer benefit
        // Guest benefit

        return request;
    }

    private async Task CalculateTaxAmountAsync(IEnumerable<TransactionItem> transactionItems)
    {
        var itemIds = transactionItems.Select(x => x.ItemId).Distinct();

        var taxes = await _taxRepository.GetTaxesAsync();
        var cartItems = await _itemRepository.GetCartItemsAsync(itemIds);

        var itemTaxes = new Dictionary<long, Domain.Entities.Tax>();

        foreach (var item in cartItems)
        {
            itemTaxes.Add(item.Id, taxes.FirstOrDefault(x => x.Id == item.TaxId));
        }

        if (itemTaxes.Any())
        {
            foreach (var item in transactionItems)
            {
                var tax = itemTaxes[item.Id];
                item.Tax = new Tax
                {
                    Id = tax.Id,
                    Name = tax.Name,
                    Description = tax.Description,
                    Percentage = tax.Percentage,
                    Amount = item.Quantity * item.UnitPrice * tax.Percentage / 100
                };
            }
        }
    }

    private void ApplyDiscountForCartItems(IEnumerable<TransactionItem> items)
    {
        foreach (var item in items)
        {
            if (item.Discount != null)
            {
                item.UnitPrice -= item.Discount.Amount;
            }
        }
    }

    private void BuildDiscountDetails(Discount discount, TransactionItem transactionItem)
    {

    }
}
