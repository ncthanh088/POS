using MediatR;
using POS.Application.DTO;

namespace POS.Application.Categories.Queries;
public class BrowseCategories : IRequest<IEnumerable<CategoryDTO>>
{

}
