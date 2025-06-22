using AutoMapper;
using GL.CompanyCatalog.Application.Contracts.Persistence;
using GL.CompanyCatalog.Application.Features.Categories.Queries.GetCategoriesList;
using GL.CompanyCatalog.Application.Profiles;
using GL.CompanyCatalog.Application.UnitTests.Mocks;
using GL.CompanyCatalog.Domain.Entities;
using Moq;
using Shouldly;

namespace GL.CompanyCatalog.Application.UnitTests.Categories.Queries
{
    public class GetCategoriesListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;

        public GetCategoriesListQueryHandlerTests()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetCategoriesListTest()
        {
            var handler = new GetCategoriesListQueryHandler(_mapper, _mockCategoryRepository.Object);

            var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<CategoryListVm>>();

            result.Count.ShouldBe(4);
        }
    }
}
