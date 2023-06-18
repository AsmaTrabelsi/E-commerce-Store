using Core.Entities;
using Infrastructure.Data.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpeciifcation<Product>
    {
        public ProductWithTypesAndBrandsSpecification()
        {
            AddInclude(x => x.productType);
            AddInclude(x => x.ProductBrand);
        }
        public ProductWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.productType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
