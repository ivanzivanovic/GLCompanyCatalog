using MediatR;

namespace GL.CompanyCatalog.Application.Features.Companies.Queries.GetCompaniesList
{
    public class GetCompaniesListQuery : IRequest<List<CompanyListVm>>
    {
    }
}
