using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Stroy.kg.Models
{
    public class Product2
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name= "Short Desc")]
        public string ShortDesc { get; set; }
        public string? Description { get; set; }
        [Range(1, int.MaxValue)]
        public double price { get; set; }
        public string? Image { get; set; }
        [Display(Name = "Category Type")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual CategoryM? Category { get; set; }
        [Display(Name="Application Type")]
        public int ApplicationId { get; set; }
        [ForeignKey("ApplicationId")]
        public virtual ApplicationType? ApplicationType { get; set; }
    }
}
