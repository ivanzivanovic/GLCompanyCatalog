using GL.CompanyCatalog.Api.Utility;
using GL.CompanyCatalog.Application.Features.Companies.Commands.CreateCompany;
using GL.CompanyCatalog.Application.Features.Companies.Commands.DeleteCompany;
using GL.CompanyCatalog.Application.Features.Companies.Commands.UpdateCompany;
using GL.CompanyCatalog.Application.Features.Companies.Queries.GetCompanyDetail;
using GL.CompanyCatalog.Application.Features.Companies.Queries.GetCompaniesExport;
using GL.CompanyCatalog.Application.Features.Companies.Queries.GetCompaniesList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GL.CompanyCatalog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CompaniesController : Controller
    {
        private readonly IMediator _mediator;

        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetAllCompanies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<CompanyListVm>>> GetAllCompanies()
        {
            var result = await _mediator.Send(new GetCompaniesListQuery());
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetCompanyById")]
        public async Task<ActionResult<CompanyDetailVm>> GetCompanyById(Guid id)
        {
            var getCompanyDetailQuery = new GetCompanyDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getCompanyDetailQuery));
        }

        [HttpPost(Name = "CreateCompany")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCompanyCommand CreateCompanyCommand)
        {
            var id = await _mediator.Send(CreateCompanyCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateCompany")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateCompanyCommand UpdateCompanyCommand)
        {
            await _mediator.Send(UpdateCompanyCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteCompany")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var DeleteCompanyCommand = new DeleteCompanyCommand() { CompanyId = id };
            await _mediator.Send(DeleteCompanyCommand);
            return NoContent();
        }

      
    }
}
