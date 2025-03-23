namespace E_CommerceApp.Models
{
    public class Customer
    {

        public int Id { get; set; }

        public string CustomerName { get; set; }

        public string Email { get; set; } 

        //store password in plain text
        public string Password { get; set; }

        public string Phone { get; set; }

        public string BillingAddress { get; set; }

       public List<Order> oders { get; set; }
    }
}
