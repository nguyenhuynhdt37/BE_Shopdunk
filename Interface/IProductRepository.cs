using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE_Shopdunk.Dtos.ProductDto;

namespace BE_Shopdunk.Interface
{
    public interface IProductRepository
    {
        public Task ProductCreateAsync(ProductCreateDto product);
    }
}