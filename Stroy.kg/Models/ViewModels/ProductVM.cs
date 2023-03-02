using Microsoft.AspNetCore.Mvc.Rendering;

namespace Stroy.kg.Models.ViewModels
{
    public class ProductVM
    {
        public Product2? Product2 { get; set; }
        public IEnumerable<SelectListItem>? ApplicationSelectList { get; set; }
        public IEnumerable<SelectListItem>? CategorySelectList { get; set; }
    }
}
