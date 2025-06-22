using AutoMapper;
using GL.CompanyCatalog.WebApp.Services;
using GL.CompanyCatalog.WebApp.ViewModels;

namespace GL.CompanyCatalog.WebApp.Profiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            //Vms are coming in from the API, ViewModel are the local entities in Blazor
            CreateMap<CompanyListVm, CompanyListViewModel>().ReverseMap();
            CreateMap<CompanyDetailVm, CompanyDetailViewModel>().ReverseMap();

            CreateMap<CompanyDetailViewModel, CreateCompanyCommand>().ReverseMap();
            CreateMap<CompanyDetailViewModel, UpdateCompanyCommand>().ReverseMap();

            CreateMap<CategoryCompanyDto, CompanyNestedViewModel>().ReverseMap();

            CreateMap<CategoryDto, CategoryViewModel>().ReverseMap();
            CreateMap<CategoryListVm, CategoryViewModel>().ReverseMap();
            CreateMap<CategoryCompanyListVm, CategoryCompaniesViewModel>().ReverseMap();
            CreateMap<CreateCategoryCommand, CategoryViewModel>().ReverseMap();
            CreateMap<CreateCategoryDto, CategoryDto>().ReverseMap();

       }
    }
}
