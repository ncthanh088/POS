using MediatR;
using POS.Application.DTO;
using POS.Application.Repositories;

namespace POS.Application.Categories.Queries.Handlers;

public class BrowseCategoriesHandler : IRequestHandler<BrowseCategories, IEnumerable<CategoryDTO>>
{
    private readonly ICategoriesRepository _categoriesRepository;

    public BrowseCategoriesHandler(ICategoriesRepository categoriesRepository)
    {
        _categoriesRepository = categoriesRepository;
    }

    public async Task<IEnumerable<CategoryDTO>> Handle(BrowseCategories request, CancellationToken cancellationToken)
    {
        return await _categoriesRepository.GetCategoriesAsync();
    }
}
