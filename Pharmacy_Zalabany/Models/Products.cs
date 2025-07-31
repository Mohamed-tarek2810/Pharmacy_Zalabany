using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Zalabany.Models
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public bool Status { get; set; }
        public string MainImg { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public double Rate { get; set; }
        public double Discount { get; set; }
        public int Traffic { get; set; }

        public int CategoryId { get; set; }

        public Categorys Category { get; set; } = null!;
    }
}

