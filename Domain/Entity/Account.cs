using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Account
    {
        [Required]
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
    }
}
