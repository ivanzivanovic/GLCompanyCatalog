using AutoMapper;
using GL.CompanyCatalog.Application.Features.Categories.Commands.CreateCateogry;
using GL.CompanyCatalog.Application.Features.Categories.Queries.GetCategoriesList;
using GL.CompanyCatalog.Application.Features.Categories.Queries.GetCategoriesListWithCompanies;
using GL.CompanyCatalog.Application.Features.Companies.Commands.CreateCompany;
using GL.CompanyCatalog.Application.Features.Companies.Commands.UpdateCompany;
using GL.CompanyCatalog.Application.Features.Companies.Queries.GetCompaniesExport;
using GL.CompanyCatalog.Application.Features.Companies.Queries.GetCompaniesList;
using GL.CompanyCatalog.Domain.Entities;
using GL.CompanyCatalog.Application.Features.Companies.Queries.GetCompanyDetail;

namespace GL.CompanyCatalog.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyListVm>().ReverseMap();
            CreateMap<Company, CompanyDetailVm>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryListVm>().ReverseMap();
            CreateMap<Category, CategoryCompanyListVm>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Company, CategoryCompanyDto>().ReverseMap();
            CreateMap<Company, CompanyExportDto>().ReverseMap();

            CreateMap<Company, CreateCompanyCommand>().ReverseMap();
            CreateMap<Company, UpdateCompanyCommand>().ReverseMap();

        }
    }
}
