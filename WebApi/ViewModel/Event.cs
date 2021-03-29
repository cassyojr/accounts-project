using System.ComponentModel.DataAnnotations;

namespace Accounts.Project.ViewModel
{
    public class Event
    {
        [Required]
        public string Type { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
