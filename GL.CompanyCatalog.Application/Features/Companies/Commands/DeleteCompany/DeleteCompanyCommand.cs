using MediatR;

namespace GL.CompanyCatalog.Application.Features.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommand : IRequest
    {
        public Guid CompanyId { get; set; }
    }
}
