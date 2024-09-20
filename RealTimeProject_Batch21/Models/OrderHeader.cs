using System.ComponentModel.DataAnnotations.Schema;

namespace RealTimeProject_Batch21.Models
{
    public class OrderHeader
    {
        public int OrderHeaderId { get; set; }

        public string ApplicationUserId {  get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime OrderDate { get; set; } 

        public DateTime ShippingDate { get; set; }  
        public double OrderTotal { get; set; }
        public string? OrderStatus { get; set; }
        public string? PaymentStatus { get; set; }
    }
}
