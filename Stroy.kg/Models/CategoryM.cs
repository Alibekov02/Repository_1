using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stroy.kg.Models
{
    public class CategoryM
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
		[Required]
        [Range(1, int.MaxValue ,ErrorMessage ="Порядок отображение должен быть болшье нулья")]
		public int DisplayOrder { get; set; }
    }
}
