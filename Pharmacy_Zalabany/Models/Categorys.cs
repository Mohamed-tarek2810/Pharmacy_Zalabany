using System.ComponentModel.DataAnnotations;

namespace Pharmacy_Zalabany.Models
{
    public class Categorys
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool Status { get; set; }

        public ICollection<Products> Products { get; } = new List<Products>();
    }
}

