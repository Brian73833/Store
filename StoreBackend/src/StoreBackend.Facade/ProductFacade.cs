using System;
using StoreBackend.DomainService;
using StoreBackend.Dto;
using StoreBackend.Exceptions;
using StoreBackend.Facade.Mappers;
using StoreBackend.Infrastructure;

namespace StoreBackend.Facade;

public class ProductFacade : IProductFacade
{
    private readonly IProductService productSevice;
    private readonly AppDbContext context;

    public ProductFacade(IProductService productSevice, AppDbContext context)
    {
        this.productSevice = productSevice;
        this.context = context;
    }

    public async Task<ProductDto> AddAsync(ProductDto product)
    {
        var entity = await productSevice.AddAsync(product);
        await context.SaveChangesAsync();
        return ProductMapper.ToDto(entity);
    }

    public async Task DeleteAsync(Guid productId)
    {
        await productSevice.DeleteAsync(productId);
        await context.SaveChangesAsync();
    }

    public async Task<List<ProductDto>> GetAllAsync()
    {
        var entities = await productSevice.GetAllAsync();
        return ProductMapper.ToDto(entities);
    }

    public async Task<ProductDto> GetByIdAsync(Guid productId)
    {
        var entity = await productSevice.GetByIdAsync(productId);
        if (entity == null) throw new ResourceNotFoundException();
        return ProductMapper.ToDto(entity);
    }
}
