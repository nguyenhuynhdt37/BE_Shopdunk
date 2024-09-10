using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE_Shopdunk.Dtos.ProductDto
{
    public class ProductBannerDto
    {
        public string? Id { get; set; }

        public string? Name { get; set; }

        public string? ImageCover { get; set; }

        public double Price { get; set; }

        public double OldPrice { get; set; }
    }
}