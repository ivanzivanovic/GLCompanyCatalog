using System;
using System.Collections.Generic;

namespace GL.CompanyCatalog.Application.Features.Categories.Queries.GetCategoriesListWithCompanies
{
    public class CategoryCompanyListVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryCompanyDto> Companies { get; set; }
    }
}
