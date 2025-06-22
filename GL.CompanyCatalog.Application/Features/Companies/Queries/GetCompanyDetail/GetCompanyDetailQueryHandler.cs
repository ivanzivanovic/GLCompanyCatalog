using AutoMapper;
using GL.CompanyCatalog.Application.Contracts.Persistence;
using GL.CompanyCatalog.Domain.Entities;
using MediatR;

namespace GL.CompanyCatalog.Application.Features.Companies.Queries.GetCompanyDetail
{
    public class GetCompanyDetailQueryHandler : IRequestHandler<GetCompanyDetailQuery, CompanyDetailVm>
    {
        private readonly IAsyncRepository<Company> _companyRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetCompanyDetailQueryHandler(
            IMapper mapper,
            IAsyncRepository<Company> companyRepository,
            IAsyncRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<CompanyDetailVm> Handle(GetCompanyDetailQuery request, CancellationToken cancellationToken)
        {
            var @company = await _companyRepository.GetByIdAsync(request.Id);
            var companyDetailDto = _mapper.Map<CompanyDetailVm>(@company);

            var category = await _categoryRepository.GetByIdAsync(@company.CategoryId);

            companyDetailDto.Category = _mapper.Map<CategoryDto>(category);

            return companyDetailDto;
        }
    }
}
