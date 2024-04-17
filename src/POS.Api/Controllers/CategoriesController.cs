using MediatR;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Categories.Queries;

namespace POS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _mediator.Send(new BrowseCategories());

            return Ok(response);
        }
    }
}
