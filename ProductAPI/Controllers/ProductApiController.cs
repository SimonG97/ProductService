using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Dto;
using ProductAPI.IRepository;

namespace ProductAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductApiController : ControllerBase
{
    private protected ResponseDto _response;
    private readonly IProductRepository _productRepository;

    public ProductApiController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
        _response = new ResponseDto();
    }

    [HttpGet]
    [Authorize]
    public async Task<object> Get()
    {
        try
        {
            IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
            _response.Result = productDtos;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { ex.ToString() };
        }
        return _response;
    }

    [HttpGet]
    [Authorize]
    [Route("{id}")]
    public async Task<object> Get(int id)
    {
        try
        {
            ProductDto productDto = await _productRepository.GetProductById(id);
            _response.Result = productDto;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { ex.ToString() };
        }
        return _response;
    }

    [HttpPost]
    [Authorize]
    public async Task<object> Post([FromBody] ProductDto productDto)
    {
        try
        {
            ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
            _response.Result = model;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { ex.ToString() };
        }
        return _response;
    }

    [HttpPut]
    [Authorize]
    public async Task<object> Put([FromBody] ProductDto productDto)
    {
        try
        {
            ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
            _response.Result = model;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { ex.ToString() };
        }
        return _response;
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    [Route("{id}")]
    public async Task<object> Delete(int id)
    {
        try
        {
            bool isSuccess = await _productRepository.DeleteProduct(id);
            _response.Result = isSuccess;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { ex.ToString() };
        }
        return _response;
    }
}
