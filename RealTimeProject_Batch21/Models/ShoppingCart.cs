using System.ComponentModel.DataAnnotations.Schema;

namespace RealTimeProject_Batch21.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int Count { get; set; }
        public string UserId { get; set; }
        public double Price { get; set; }
    }
}
