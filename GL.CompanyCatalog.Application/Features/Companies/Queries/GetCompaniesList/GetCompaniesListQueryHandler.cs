using AutoMapper;
using GL.CompanyCatalog.Application.Contracts.Persistence;
using GL.CompanyCatalog.Domain.Entities;
using MediatR;

namespace GL.CompanyCatalog.Application.Features.Companies.Queries.GetCompaniesList
{
    public class GetCompaniesListQueryHandler : IRequestHandler<GetCompaniesListQuery, List<CompanyListVm>>
    {
        private readonly IAsyncRepository<Company> _companyRepository;
        private readonly IMapper _mapper;

        public GetCompaniesListQueryHandler(IMapper mapper, IAsyncRepository<Company> companyRepository)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        public async Task<List<CompanyListVm>> Handle(GetCompaniesListQuery request, CancellationToken cancellationToken)
        {
            var allCompanys = (await _companyRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<CompanyListVm>>(allCompanys);
        }
    }
}
