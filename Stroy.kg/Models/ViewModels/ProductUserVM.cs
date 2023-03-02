namespace Stroy.kg.Models.ViewModels
{
    public class ProductUserVM
    {
        public ProductUserVM()
        {
            ProductList = new List<Product2>();
        }
        public ApplicationUser ApplicationUser { get; set; }
        public List<Product2> ProductList { get; set; }

    }
}
