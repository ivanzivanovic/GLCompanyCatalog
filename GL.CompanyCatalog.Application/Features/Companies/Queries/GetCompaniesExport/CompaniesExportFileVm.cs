namespace GL.CompanyCatalog.Application.Features.Companies.Queries.GetCompaniesExport
{
    public class CompaniesExportFileVm
    {
        public string CompaniesExportFileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[]? Data { get; set; }
    }
}