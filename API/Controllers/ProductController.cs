using API.Data;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
 
    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> productRepo;
        private readonly IGenericRepository<ProductBrand> brandRepo;
        private readonly IGenericRepository<ProductType> typesRepo;
        private readonly IMapper mapper;


        public ProductController(IGenericRepository<Product> productRepo
            , IGenericRepository<ProductBrand> brandRepo,
            IGenericRepository<ProductType> typesRepo,
            IMapper mapper)
        {
            this.productRepo = productRepo;
            this.brandRepo = brandRepo;
            this.typesRepo = typesRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturn>>> GetProducts(
            [FromQuery] ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);
            var countSpec = new ProductsWithFiltersForCountSpecification(productParams);

            var totalItems = await productRepo.CountAsync(countSpec);
            var products = await productRepo.ListAsync(spec);

            var data = mapper.Map<IReadOnlyList<ProductToReturn>>(products);

            return Ok(new Pagination<ProductToReturn>(productParams.PageIndex,
                productParams.PageSize, totalItems, data));
        }

      

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await productRepo.GetEntityWithSpec(spec);

            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(mapper.Map<Product,ProductToReturn>(product));
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await brandRepo.GetAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await typesRepo.GetAllAsync());
           
        }
    }
}
