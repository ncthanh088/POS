using MediatR;
using POS.Domain.Types;
using POS.Application.DTO;
using POS.Application.Repositories;
using POS.Application.Utility;

namespace POS.Application.Categories.Queries.Handlers;

public class BrowseCategoriesHandler : IRequestHandler<BrowseCategories, IEnumerable<CategoryDto>>
{
    private readonly ICategoryRepository _categoriesRepository;
    private readonly IPosUtility _utility;

    public BrowseCategoriesHandler(ICategoryRepository categoriesRepository, IPosUtility utility)
    {
        _categoriesRepository = categoriesRepository;
        _utility = utility;
    }

    public async Task<IEnumerable<CategoryDto>> Handle(BrowseCategories request, CancellationToken cancellationToken)
    {
        var categories = await _categoriesRepository.GetCategoriesAsync();

        foreach (var category in categories)
        {
            category.Icon = category.Icon.ReadSvgContent(_utility.GetImageUrl());
        }
        return categories;
    }
}
