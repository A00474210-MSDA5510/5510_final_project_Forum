using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _5510_final_project_Forum.Models
{
    public class CreditCard
    {
        [Display(Name = "Credit Card No")]
        public string CreditCardId { get; set; }
        [Display(Name = "Credit Card Type")]
        public string Type { get; set; }
        [Display(Name = "Card Expiry Date")]
        [DisplayFormat(DataFormatString = "{0:MM/YYYY}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }
        [Display(Name = "Cardholder Name")]
        public string CardholderName { get; set; }
        [Required]
        [StringLength(3,MinimumLength = 3)]
        public int Cvv { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<Payment> Payments { get; set; }

        
    }
}
