using MediatR;
using POS.Domain.Enums;
using POS.Application.Services;
using POS.Application.Repositories;

namespace POS.Application.Payments.Commands.Handlers;

public class CalculateSaleTransactionHandler : IRequestHandler<CalculateSaleTransaction, CalculateSaleTransaction>
{
    private readonly IPaymentService _paymentService;
    private readonly ITaxRepository _taxRepository;
    private readonly IItemRepository _itemRepository;
    private const string RoundingOverridingConfiguration = "0,0.05;0|0.05;0.05|0.05,1.0;0.05";

    public CalculateSaleTransactionHandler(IPaymentService paymentService, ITaxRepository taxRepository, IItemRepository itemRepository)
    {
        _paymentService = paymentService;
        _taxRepository = taxRepository;
        _itemRepository = itemRepository;
    }

    public async Task<CalculateSaleTransaction> Handle(CalculateSaleTransaction request, CancellationToken cancellationToken)
    {
        await CalculateItemPriceAsync(request);
        request.RoundingAmount = _paymentService.CalculateRoundedRemainder(request.Total, decimal.Zero,
            RoundingOverridingConfiguration);

        // Calculate Tender Amount 
        if (request.RoundingAmount != decimal.Zero)
        {
            request.Tenders.Add(new TransactionTender
            {
                SequenceNumber = (short)(request.Tenders.Count + 1),
                Type = TenderType.Rounding,
                Amount = request.RoundingAmount,
            });
        }
        return request;
    }


    private Task CalculateItemPriceAsync(CalculateSaleTransaction request)
    {
        request.Taxes = CalculateTaxAmount(request.Items);
        foreach (var item in request.Items)
        {
            ApplyDiscount(item);
        }
        return Task.CompletedTask;
    }

    private IEnumerable<TransactionTax> CalculateTaxAmount(ICollection<TransactionItem> items)
    {
        var transactionTaxes = new List<TransactionTax>();
        foreach (var item in items)
        {
            transactionTaxes.Add(new TransactionTax
            {
                Id = item.Tax.Id,
                Name = item.Tax.Name,
                Description = item.Tax.Description,
                Amount = item.TotalTax,
                TaxableAmount = item.TotalPriceExcludingTax,
                Percentage = item.Tax.Percentage
            });
        }
        return transactionTaxes;
    }

    private async Task CalculateTaxExemptionAsync(ICollection<TransactionItem> items)
    {
        var itemIds = items.Select(x => x.ItemId).Distinct();

        var taxes = await _taxRepository.GetTaxesAsync();
        var cartItems = await _itemRepository.GetCartItemsAsync(itemIds);
        var itemTaxes = new Dictionary<int, Domain.Entities.Tax>();
        foreach (var item in cartItems)
        {
            itemTaxes.Add(item.Id, taxes.FirstOrDefault(x => x.Id == item.TaxId));
        }
        if (!itemTaxes.Any())
        {
            return;
        }
        foreach (var item in items)
        {
            var tax = itemTaxes[item.ItemId];
            item.Tax = new Tax
            {
                Id = tax.Id,
                Name = tax.Name,
                Description = tax.Description,
                Percentage = tax.Percentage,
                Amount = item.Quantity * item.RegularUnitPrice * tax.Percentage / 100
            };
        }
    }

    private void ApplyDiscount(TransactionItem item)
    {
        var discount = item.Discount;
        if (discount is null)
        {
            return;
        }
        BuildDiscountDetail(discount, item);
    }

    private void BuildDiscountDetail(Discount discount, TransactionItem item)
    {
        var priceToApplyDiscountTo = item.ActualUnitPrice;
        var discountOnFullPrice = item.ActualUnitPrice;

        if (!discount.InclusiveOfTax)
        {
            priceToApplyDiscountTo = item.ActualPriceExcludingTax;
        }
        var discountAmount = decimal.Zero;
        var quantity = 0;
        if (item.Quantity > 0)
        {
            quantity = item.Quantity;
        }
        switch (discount.Type)
        {
            case DiscountType.Percentage:
                discountAmount = priceToApplyDiscountTo * (discount.Amount / 100);
                discountOnFullPrice = item.ActualUnitPrice * (discount.Amount / 100);
                break;
            case DiscountType.Amount:
                discountAmount = discount.Amount;
                discountOnFullPrice = Math.Round(discountAmount / quantity, 2);
                break;
            case DiscountType.Fixed:
                // ALWAYS work on actual retail price for fixed price (regardless of exc/inc tax).
                discountAmount = item.ActualUnitPrice - discount.Amount;
                discountOnFullPrice = Math.Round(discountAmount / quantity, 2);
                break;
        }
        discountAmount = Math.Round(discountAmount, 2);
        discountOnFullPrice = Math.Round(discountOnFullPrice, 2);
        if (discount.InclusiveOfTax)
        {
            var actualRetailPriceAfterDiscount =
                Math.Round(item.ActualUnitPrice - discountAmount, 2);
            CalculateDiscountAmount(item, discountAmount,
                actualRetailPriceAfterDiscount);
        }
        else
        {
            var newtax = item.CalculateTax(item.ActualUnitPrice - discountOnFullPrice);
            var actualRetailPriceAfterDiscount =
                Math.Round(item.ActualPriceExcludingTax - discountAmount + newtax, 2);

            CalculateDiscountAmount(item, discountAmount,
                actualRetailPriceAfterDiscount);
        }
    }

    private void CalculateDiscountAmount(TransactionItem item, decimal discountAmount, decimal actualPriceAfterDiscount)
    {
        item.BeforeDiscountUnitPrice = item.ActualUnitPrice;
        item.ExtendedPriceExcludingDiscount = item.TotalPrice;
        if (discountAmount >= item.ActualUnitPrice)
        {
            var extendedDiscountAmount = item.ActualUnitPrice * -1;
            item.ExtendedDiscountAmount = extendedDiscountAmount;

            item.Discount.Amount = item.ActualUnitPrice;
            item.ActualUnitPrice = 0;
        }
        else
        {
            item.ActualUnitPrice = actualPriceAfterDiscount;
            var extendedDiscountAmount = discountAmount * item.Quantity * -1;
            item.ExtendedDiscountAmount = extendedDiscountAmount;
        }
    }
}
