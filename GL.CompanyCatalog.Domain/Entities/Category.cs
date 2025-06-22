
using GL.CompanyCatalog.Domain.Common;

namespace GL.CompanyCatalog.Domain.Entities
{
    public class Category: AuditableEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Company>? Companies { get; set; }
    }
}
