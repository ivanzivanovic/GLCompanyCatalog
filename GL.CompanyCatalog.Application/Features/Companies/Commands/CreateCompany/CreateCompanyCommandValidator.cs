using FluentValidation;
using GL.CompanyCatalog.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.CompanyCatalog.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        private readonly ICompanyRepository _companyRepository;
        public CreateCompanyCommandValidator(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Exchange)
                  .NotEmpty().WithMessage("{PropertyName} is required.")
                  .NotNull()
                  .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(e => e.Ticker)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Length(5).WithMessage("Ticker code must be exactly 5 characters long.");

            RuleFor(x => x.Isin)
                .NotEmpty()
                .Length(12)
                .Matches(@"^[A-Za-z]{2}")
                .WithMessage("ISIN must start with two letters and be exactly 12 characters long.");

            RuleFor(p => p.Website)
                .Must(BeValidUrl)
                .When(x => !string.IsNullOrWhiteSpace(x.Website))
                .WithMessage("Website must be a valid URL if provided."); ;
           
            RuleFor(p => p)
                .MustAsync(HaveUniqueNameInCategory)
                .WithMessage("An company with the same name and category already exists.");        
        }

        private async Task<bool> HaveUniqueNameInCategory(CreateCompanyCommand c, CancellationToken token)
        {
            return !await _companyRepository.HaveUniqueNameInCategory(c.Name, c.CategoryId);
        }

        private bool BeValidUrl(string website)
        {
            if (!website.StartsWith("http://") && !website.StartsWith("https://"))
            {
                website = "https://" + website;
            }

            return Uri.TryCreate(website, UriKind.Absolute, out var uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
