using GL.CompanyCatalog.Application.Contracts;
using GL.CompanyCatalog.Domain.Common;
using GL.CompanyCatalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GL.CompanyCatalog.Persistence
{
    public class GLDbContext : DbContext
    {
        private readonly ILoggedInUserService? _loggedInUserService;

        public GLDbContext(DbContextOptions<GLDbContext> options)
           : base(options)
        {
        }

        public GLDbContext(DbContextOptions<GLDbContext> options, ILoggedInUserService loggedInUserService)
            : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GLDbContext).Assembly);

            // ✅ 1) GUIDs for categories:
            // ✅ 1) Realistic category GUIDs
            var technologyGuid = Guid.Parse("a1c4e7b2-42b3-4e5d-b799-3f40b10f6a23");
            var aviationGuid = Guid.Parse("b2d5f8c3-53c4-4f6e-a89a-4e51c21f7b34");
            var beverageGuid = Guid.Parse("c3e6d9d4-64d5-407f-b9ab-5f62d32f8c45");
            var electronicsGuid = Guid.Parse("d4f7e1e5-75e6-4180-cabc-6a73e43f9d56");
            var automotiveGuid = Guid.Parse("e5f8e2f6-86f7-4291-dbcd-7b84f54f0e67");

            // ✅ 2) Seed categories (one moraš imati)
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = technologyGuid, Name = "Technology" },
                new Category { CategoryId = aviationGuid, Name = "Aviation" },
                new Category { CategoryId = beverageGuid, Name = "Beverages" },
                new Category { CategoryId = electronicsGuid, Name = "Electronics" },
                new Category { CategoryId = automotiveGuid, Name = "Automotive" }
            );

            // ✅ 3) Seed companies sa svim poljima modela:
            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    CompanyId = Guid.Parse("EE272F8B-6096-4CB6-8625-BB4BB2D89E8B"),
                    Name = "Apple Inc.",
                    Exchange = "NASDAQ",
                    Ticker = "AAPLA",
                    Isin = "US0378331005",
                    Website = "http://www.apple.com",
                    ImageUrl = "https://logo.clearbit.com/apple.com",
                    CategoryId = technologyGuid
                },
                new Company
                {
                    CompanyId = Guid.Parse("3448D5A4-0F72-4DD7-BF15-C14A46B26C00"),
                    Name = "British Airways Plc",
                    Exchange = "Pink sheets",
                    Ticker = "BAIRY",
                    Isin = "US1104193065",
                    Website = "https://www.britishairways.com",
                    ImageUrl = "https://logo.clearbit.com/britishairways.com",
                    CategoryId = aviationGuid
                },
                new Company
                {
                    CompanyId = Guid.Parse("B419A7CA-3321-4F38-BE8E-4D7B6A529319"),
                    Name = "Heineken NV",
                    Exchange = "Euronext Amsterdam",
                    Ticker = "HEIAD",
                    Isin = "NL0000009165",
                    Website = "https://www.theheinekencompany.com",
                    ImageUrl = "https://logo.clearbit.com/theheinekencompany.com",
                    CategoryId = beverageGuid
                },
                new Company
                {
                    CompanyId = Guid.Parse("62787623-4C52-43FE-B0C9-B7044FB5929B"),
                    Name = "Panasonic Corp",
                    Exchange = "Tokyo Stock Exchange",
                    Ticker = "6752D",
                    Isin = "JP3866800000",
                    Website = "http://www.panasonic.co.jp",
                    ImageUrl = "https://logo.clearbit.com/panasonic.com",
                    CategoryId = electronicsGuid
                },
                new Company
                {
                    CompanyId = Guid.Parse("ADC42C09-08C1-4D2C-9F96-2D15BB1AF299"),
                    Name = "Porsche Automobil",
                    Exchange = "Deutsche Börse",
                    Ticker = "PAH3D",
                    Isin = "DE000PAH0038",
                    Website = "https://www.porsche.com/",
                    ImageUrl = "https://logo.clearbit.com/porsche.com",
                    CategoryId = automotiveGuid
                }
                        );





        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
