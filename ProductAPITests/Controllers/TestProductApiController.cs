using Moq;
using ProductAPI.Dto;
using ProductAPI.IRepository;
using ProductAPITests.MockData;

namespace ProductAPITests.Controllers;

public class TestProductApiController
{
    private protected ResponseDto _response;
    private readonly Mock<IProductRepository> _productRepository;

    public TestProductApiController(ResponseDto response, Mock<IProductRepository> productRepository)
    {
        _response = response;
        _productRepository = productRepository;
    }

    [Fact]
    public async Task Get_ShouldReturnIsSuccessTrue()
    {
        //Arrange

        //Act


        //Assert
    }
}
