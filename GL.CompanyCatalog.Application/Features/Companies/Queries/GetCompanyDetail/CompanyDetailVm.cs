using System;

namespace GL.CompanyCatalog.Application.Features.Companies.Queries.GetCompanyDetail
{
    public class CompanyDetailVm
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public string Exchange { get; set; } = string.Empty;
        public string Ticker { get; set; } = string.Empty;
        public string Isin { get; set; } = string.Empty;
        public string? Website { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}