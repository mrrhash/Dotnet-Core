using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class OrderDetail
    {
        [Key]
        public long OrderDetailID { get; set; }

        public long OrderMasterID { get; set; }
        
        public int FoodItemID { get; set; }
        public FoodItem FoodItem { get; set; }

        public decimal FoodItemPrice { get; set; }

        public int Quantity { get; set; }
    }
}
