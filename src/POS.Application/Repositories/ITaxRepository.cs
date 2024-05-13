using POS.Domain.Entities;

namespace POS.Application.Repositories;

public interface ITaxRepository
{
    // TODO: Simple get Tax on
    Task<IEnumerable<Tax>> GetTaxesAsync();
}
