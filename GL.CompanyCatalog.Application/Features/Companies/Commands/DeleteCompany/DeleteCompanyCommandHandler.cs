using AutoMapper;
using GL.CompanyCatalog.Application.Contracts.Persistence;
using GL.CompanyCatalog.Domain.Entities;
using MediatR;

namespace GL.CompanyCatalog.Application.Features.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
    {
        private readonly IAsyncRepository<Company> _companyRepository;
        private readonly IMapper _mapper;

        public DeleteCompanyCommandHandler(IMapper mapper, IAsyncRepository<Company> companyRepository)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        public async Task Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyToDelete = await _companyRepository.GetByIdAsync(request.CompanyId);

            await _companyRepository.DeleteAsync(companyToDelete);
        }
    }
}
