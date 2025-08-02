namespace Pharmacy_Zalabany.Models
{
    public class RelatedandtopVm
    {
        public List<Products>? product { get; set; } 
        public List<Products>? relatedProducts { get; set; }
        public List<Products>? TopProducts { get; set; }
        public List<Categorys?> Categorys { get; set; }
        public List<Notes>? Notes { get; set; }


    }
}

