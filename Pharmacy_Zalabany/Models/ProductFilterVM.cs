﻿namespace Pharmacy_Zalabany.Models
{
    public class ProductFilterVM
    {
        public string? ProductName { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public int CategoryId { get; set; }
        public bool IsHot { get; set; }
    }
}
