using POS.Domain.Entities;

namespace POS.Application.Repositories;

public interface ILineItemRepository
{
    Task CreateSaleLineItemAsync(SaleLineItem saleLineItem);
    Task CreateTaxLineItemAsync(TaxLineItem taxLineItem);
    Task CreateTenderLineItemAsync(TenderLineItem tenderLineItem);
}
