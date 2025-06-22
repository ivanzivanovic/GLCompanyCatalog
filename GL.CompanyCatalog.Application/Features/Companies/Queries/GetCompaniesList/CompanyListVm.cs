namespace GL.CompanyCatalog.Application.Features.Companies.Queries.GetCompaniesList
{
    public class CompanyListVm
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Isin { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
    }
}