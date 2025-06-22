using MediatR;
using System.Collections.Generic;

namespace GL.CompanyCatalog.Application.Features.Categories.Queries.GetCategoriesListWithCompanies
{
    public class GetCategoriesListWithCompaniesQuery : IRequest<List<CategoryCompanyListVm>>
    {
    }
}
