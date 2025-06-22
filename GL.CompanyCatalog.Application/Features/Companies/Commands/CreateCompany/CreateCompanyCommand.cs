using MediatR;

namespace GL.CompanyCatalog.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Exchange { get; set; } = string.Empty;
        public string Ticker { get; set; } = string.Empty;
        public string Isin { get; set; } = string.Empty;
        public string? Website { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public override string ToString()
        {
            return $"Company name: {Name}; Exchange: {Exchange}; Ticker: {Ticker}; ISIN: {Isin}; Website: {Website}; CategoryId: {CategoryId}";
        }
    }
}
