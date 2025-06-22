namespace GL.CompanyCatalog.WebApp.ViewModels
{
    public class CategoryCompaniesViewModel
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<CompanyNestedViewModel>? Companies { get; set; }
    }
}
