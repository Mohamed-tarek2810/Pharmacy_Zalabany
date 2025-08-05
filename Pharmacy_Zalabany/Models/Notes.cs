using System.ComponentModel.DataAnnotations;

namespace Pharmacy_Zalabany.Models
{
    public class Notes
    {
        [Key]
        public int id { get; set; }
        public int number { get; set; }
        public string? notes { get; set; }

        public string? Auther { get; set; }
    }
}

