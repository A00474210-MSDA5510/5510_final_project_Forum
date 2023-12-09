using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _5510_final_project_Forum.Models
{
    public class CreditCard
    {
        [Required]
        [Display(Name = "Credit Card No")]
        [Remote("ValidateCreditCardNo", "Subscriptions", AdditionalFields = "Type", ErrorMessage = "Invalid Credit Card Id")]
        public string CreditCardId { get; set; }
        [Required]
        [Display(Name = "Credit Card Type")]
        public string Type { get; set; }
        [Required]
        [Display(Name = "Card Expiry Date")]
        [DisplayFormat(DataFormatString = "{0:MM/YYYY}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^(0[1-9]|1[0-2])/(201[6-9]|202[0-9]|203[0-1])$",ErrorMessage = "Invalid Date. Format:MM/YYYY Range:2016-2031")]
        public string ExpiryDate { get; set; }
        [Required]
        [Display(Name = "Cardholder Name")]
        [RegularExpression(@"^[a-zA-Z]+(?:['-][a-zA-Z]+)?$", ErrorMessage = "Invalid name")] //Only alphabets and may contain atmost 1 apostrophe or hyphen in-between
        public string CardholderName { get; set; }
        [Required]
        [StringLength(3,MinimumLength = 3,ErrorMessage = "CVV should be 3 digits only")]
        public int Cvv { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<Payment> Payments { get; set; }

        
    }
}
