﻿using MicroMultiBusiness.DTOLayer.CatalogDTOs.CategoryDTOs;

namespace MicroMultiBusiness.DTOLayer.CatalogDTOs.ProductDTOs
{
    public class ResultProductWtihCategoryDTO
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public string ProductImageUrl { get; set; }

        public string ProductDescription { get; set; }

        public ResultCategoryDTO Category { get; set; }
    }
}
