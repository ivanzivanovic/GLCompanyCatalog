using MediatR;

namespace GL.CompanyCatalog.Application.Features.Companies.Queries.GetCompaniesExport
{
    public class GetCompaniesExportQuery: IRequest<CompaniesExportFileVm>
    {
    }
}
