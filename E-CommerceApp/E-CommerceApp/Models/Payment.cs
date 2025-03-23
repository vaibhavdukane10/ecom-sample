using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceApp.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public int OrderId {  get; set; }

        public Order Order { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal AmountPaid { get; set; }
        //credit,cod,paypal
        public string PaymentMethod { get; set; }
        //pending,complete
        public string PaymentStatus {  get; set; }

        public DateTime PaymentDate { get; set; }  
        

    }
}
