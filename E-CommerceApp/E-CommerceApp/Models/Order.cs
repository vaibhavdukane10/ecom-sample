using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public string OrderName { get; set; }

        public DateTime OrderDate { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        [Column(TypeName ="decimal(18,2)")]
        public decimal TotalAmout { get; set; }

        //pending,complete
        public string OrderStatus { get; set; }

        public DateTime CreatedDate { get; set; }

        //Navigation property for one to one relation
        public Payment Payment { get; set; }

    }
}
