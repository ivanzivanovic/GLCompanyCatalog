using CsvHelper;
using GL.CompanyCatalog.Application.Contracts.Infrastructure;
using GL.CompanyCatalog.Application.Features.Companies.Queries.GetCompaniesExport;

namespace GL.CompanyCatalog.Infrastructure.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportCompaniesToCsv(List<CompanyExportDto> companyExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter);
                csvWriter.WriteRecords(companyExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
