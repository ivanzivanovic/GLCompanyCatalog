namespace GL.CompanyCatalog.WebApp.ViewModels
{
    public class CompanyListViewModel
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Isin { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
    }
}
