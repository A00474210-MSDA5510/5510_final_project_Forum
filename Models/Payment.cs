namespace _5510_final_project_Forum.Models
{
    public class Payment
    {
        public string PaymentId { get; set; }
        public string Amount { get; set; }
        public ApplicationUser User { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}
