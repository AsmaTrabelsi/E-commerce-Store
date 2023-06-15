using API.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _storeContext;
        public ProductRepository(StoreContext context)
        {
            this._storeContext = context;
        }
        public async Task<IReadOnlyList<Product>> GetAllProductsAsync()
        {
            return await _storeContext.Products.Include(p => p.ProductBrand).Include(p=> p.productType).ToListAsync();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _storeContext.Products.Include(p => p.ProductBrand).Include(p => p.productType).FirstOrDefaultAsync(p=> p.Id == id);
        }

        public async Task<IReadOnlyList<ProductBrand>> GetAllProductBrandsAsync()
        {
            return await _storeContext.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetAllProductTypesAsync()
        {
            return await _storeContext.ProductTypes.ToListAsync();
        }
    }
}
