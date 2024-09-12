using RealTimeProject_Batch21.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RealTimeProject_Batch21.DTO
{
    //DTo-data trasfer object or View Model they are same thing just the naming convention
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(10)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public float Price { get; set; }

        public string CategoryName { get; set; }
        public List<ProductImages> ProductImages { get; set; }
    }
}
