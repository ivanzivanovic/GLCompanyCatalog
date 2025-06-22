using AutoMapper;
using GL.CompanyCatalog.Application.Contracts.Infrastructure;
using GL.CompanyCatalog.Application.Contracts.Persistence;
using GL.CompanyCatalog.Application.Models.Mail;
using GL.CompanyCatalog.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GL.CompanyCatalog.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Guid>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateCompanyCommandHandler> _logger;


        public CreateCompanyCommandHandler(IMapper mapper, ICompanyRepository companyRepository, IEmailService emailService, ILogger<CreateCompanyCommandHandler> logger)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCompanyCommandValidator(_companyRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @company = _mapper.Map<Company>(request);


            @company = await _companyRepository.AddAsync(@company);


            var email = new Email() { To = "ivanzivanovic78@gmail.com", Body = $"A new company was created: {request}", Subject = "A new company was created" };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                //this shouldn't stop the API from doing else so this can be logged
                _logger.LogError($"Mailing about company {@company.CompanyId} failed due to an error with the mail service: {ex.Message}");
            }

            return @company.CompanyId;
        }
    }
}
