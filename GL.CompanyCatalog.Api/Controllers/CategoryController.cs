using GL.CompanyCatalog.Application.Features.Categories.Commands.CreateCateogry;
using GL.CompanyCatalog.Application.Features.Categories.Queries.GetCategoriesList;
using GL.CompanyCatalog.Application.Features.Categories.Queries.GetCategoriesListWithCompanies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GL.CompanyCatalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]   
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(dtos);
        }

        [HttpGet("allwithcompanies", Name = "GetCategoriesWithCompanies")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryCompanyListVm>>> GetCategoriesWithCompanies(bool includeHistory)
        {
            GetCategoriesListWithCompaniesQuery GetCategoriesListWithCompaniesQuery = new GetCategoriesListWithCompaniesQuery() { };

            var dtos = await _mediator.Send(GetCategoriesListWithCompaniesQuery);
            return Ok(dtos);
        }

        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var response = await _mediator.Send(createCategoryCommand);
            return Ok(response);
        }
    }
}
