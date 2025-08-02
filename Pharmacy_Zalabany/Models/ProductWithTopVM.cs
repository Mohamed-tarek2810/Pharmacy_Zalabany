namespace Pharmacy_Zalabany.Models
{
    public class ProductWithTopVM
    {
        public Products Product { get; set; } = null!; 
        public List<Products> TopProduct { get; set; } = null!;
    }
}
