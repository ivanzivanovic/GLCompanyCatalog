namespace GL.CompanyCatalog.Application.Features.Companies.Queries.GetCompaniesExport
{
    public class CompanyExportDto
    {
        public Guid EvenCompanytId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Exchange { get; set; } = string.Empty;
        public string Ticker { get; set; } = string.Empty;
        public string Isin { get; set; } = string.Empty;
    }
}
