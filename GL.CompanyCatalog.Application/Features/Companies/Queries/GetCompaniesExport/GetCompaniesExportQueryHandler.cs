using AutoMapper;
using GL.CompanyCatalog.Application.Contracts.Infrastructure;
using GL.CompanyCatalog.Application.Contracts.Persistence;
using GL.CompanyCatalog.Domain.Entities;
using MediatR;

namespace GL.CompanyCatalog.Application.Features.Companies.Queries.GetCompaniesExport
{
    public class GetCompaniesExportQueryHandler : IRequestHandler<GetCompaniesExportQuery, CompaniesExportFileVm>
    {
        private readonly IAsyncRepository<Company> _companyRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetCompaniesExportQueryHandler(IMapper mapper, IAsyncRepository<Company> companyRepository, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
            _csvExporter = csvExporter;
        }

        public async Task<CompaniesExportFileVm> Handle(GetCompaniesExportQuery request, CancellationToken cancellationToken)
        {
            var allCompanys = _mapper.Map<List<CompanyExportDto>>((await _companyRepository.ListAllAsync()).OrderBy(x => x.Name));

            var fileData = _csvExporter.ExportCompaniesToCsv(allCompanys);

            var companyExportFileDto = new CompaniesExportFileVm() { ContentType = "text/csv", Data = fileData, CompaniesExportFileName = $"{Guid.NewGuid()}.csv" };

            return companyExportFileDto;
        }
    }
}
