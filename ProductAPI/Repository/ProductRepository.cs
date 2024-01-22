using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductAPI.DbContexts;
using ProductAPI.Dto;
using ProductAPI.IRepository;
using ProductAPI.Models;

namespace ProductAPI.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _db;
    private IMapper _mapper;

    public ProductRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
    {
        Product product = _mapper.Map<ProductDto, Product>(productDto);
        if (product.ProductId > 0)
        {
            _db.Products.Update(product);
        }
        else
        {
            await _db.Products.AddAsync(product);
        }
        await _db.SaveChangesAsync();
        return _mapper.Map<Product, ProductDto>(product);
    }

    public async Task<bool> DeleteProduct(int productId)
    {
        try
        {
            Product product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
            if (product == null)
            {
                return false;
            }
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return true;

        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<ProductDto> GetProductById(int productId)
    {
        Product product = await _db.Products.AsNoTracking().FirstOrDefaultAsync(x => x.ProductId == productId);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<IEnumerable<ProductDto>> GetProducts()
    {
        List<Product> productList = await _db.Products.AsNoTracking().ToListAsync();
        return _mapper.Map<List<ProductDto>>(productList);

    }
}
