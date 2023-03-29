using Moq;
using ProductAPI.Dto;
using ProductAPI.IRepository;

namespace ProductAPITests.Controllers;

public class TestProductApiController
{
    private protected ResponseDto _response;
    private readonly Mock<IProductRepository> _productRepository;
    [Fact]
    public async Task Get_ShouldReturnIsSuccessTrue()
    {
        //Arrange


        //Act


        //Assert
    }
}
