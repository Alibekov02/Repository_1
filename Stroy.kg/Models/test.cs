using System.ComponentModel.DataAnnotations;

namespace Stroy.kg.Models
{
    public class test
    {
        [Key]
        public int Id { get; set; }
        public string? MyProperty { get; set; }
    }
}
