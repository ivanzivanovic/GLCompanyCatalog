using System;

namespace GL.CompanyCatalog.WebApp.ViewModels
{
    public class CompanyNestedViewModel
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Exchange { get; set; } = string.Empty;
        public string Ticker { get; set; } = string.Empty;
        public string Isin { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }

    }
}
