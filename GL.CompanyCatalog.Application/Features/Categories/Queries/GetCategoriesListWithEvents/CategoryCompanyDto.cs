using System;

namespace GL.CompanyCatalog.Application.Features.Categories.Queries.GetCategoriesListWithCompanies
{
    public class CategoryCompanyDto
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Exchange { get; set; } = string.Empty;
        public string Ticker { get; set; } = string.Empty;
        public string Isin { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
    }
}
