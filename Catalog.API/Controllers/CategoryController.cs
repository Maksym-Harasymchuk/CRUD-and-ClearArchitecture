using Catalog.API.Controllers.Base;
using Catalog.Application.Categories.Commands.AddCategory;
using Catalog.Application.Categories.Commands.DeleteCategory;
using Catalog.Application.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var request = new CategoryQuery();
            return Ok(await _mediator.Send(request));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(AddCategoryRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var request = new DeleteCategoryRequest(id);
            var result = await _mediator.Send(request, cancellationToken);

            if (result)
            {
                return NoContent(); // 204 No Content
            }

            return NotFound(); // 404 Not Found if deletion failed or item doesn't exist
        }
    }
}