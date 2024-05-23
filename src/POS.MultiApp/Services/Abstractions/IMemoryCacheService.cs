using POS.MultiApp.Models;

namespace POS.MultiApp.Services.Abstractions
{
    public interface IMemoryCacheService
    {
        Task<Configuration> GetConfigurationAsync(bool useCached = true);
        Task<User> GetUserAsync(int userId, bool useCached = true);
        Task<string> GetReceipTemplate(bool useCached = true);
        Task<Tax> GetAllTaxesAsync(bool useCached = true);
    }
}
