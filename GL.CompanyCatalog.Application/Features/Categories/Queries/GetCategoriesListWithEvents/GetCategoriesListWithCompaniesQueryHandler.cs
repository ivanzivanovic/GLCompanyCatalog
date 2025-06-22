using AutoMapper;
using GL.CompanyCatalog.Application.Contracts.Persistence;
using MediatR;

namespace GL.CompanyCatalog.Application.Features.Categories.Queries.GetCategoriesListWithCompanies
{
    public class GetCategoriesListWithCompaniesQueryHandler : IRequestHandler<GetCategoriesListWithCompaniesQuery, List<CategoryCompanyListVm>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesListWithCompaniesQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryCompanyListVm>> Handle(GetCategoriesListWithCompaniesQuery request, CancellationToken cancellationToken)
        {
            var list = await _categoryRepository.GetCategoriesWithCompanies();
            return _mapper.Map<List<CategoryCompanyListVm>>(list);
        }
    }
}
