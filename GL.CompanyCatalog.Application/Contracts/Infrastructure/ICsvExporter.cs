using GL.CompanyCatalog.Application.Features.Companies.Queries.GetCompaniesExport;
using System.Collections.Generic;

namespace GL.CompanyCatalog.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportCompaniesToCsv(List<CompanyExportDto> companyExportDtos);
    }
}
