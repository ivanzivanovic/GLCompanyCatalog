using MediatR;

namespace GL.CompanyCatalog.Application.Features.Companies.Queries.GetCompanyDetail
{
    public class GetCompanyDetailQuery : IRequest<CompanyDetailVm>
    {
        public Guid Id { get; set; }
    }
}
