using AutoMapper;
using GL.CompanyCatalog.Application.Contracts.Persistence;
using GL.CompanyCatalog.Application.Exceptions;
using GL.CompanyCatalog.Domain.Entities;
using MediatR;

namespace GL.CompanyCatalog.Application.Features.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public UpdateCompanyCommandHandler(IMapper mapper, ICompanyRepository companyRepository)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {

            var companyToUpdate = await _companyRepository.GetByIdAsync(request.CompanyId);
            
            if (companyToUpdate == null) 
            {
                throw new NotFoundException(nameof(Company), request.CompanyId);
            }

            var validator = new UpdateCompanyCommandValidator(_companyRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, companyToUpdate, typeof(UpdateCompanyCommand), typeof(Company));

            await _companyRepository.UpdateAsync(companyToUpdate);
        }
    }
}