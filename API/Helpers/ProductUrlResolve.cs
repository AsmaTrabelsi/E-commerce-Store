using API.Dtos;
using AutoMapper;
using AutoMapper.Execution;
using Core.Entities;

namespace API.Helpers
{
    public class ProductUrlResolve : IValueResolver<Product, ProductToReturn, string>
    {
        private readonly IConfiguration config;
        public ProductUrlResolve(IConfiguration config)
        { 
            this.config = config;
        }
        public string Resolve(Product source, ProductToReturn destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return config["ApiUrl"]+source.PictureUrl;
            }
            return null;
        }
    }
}
