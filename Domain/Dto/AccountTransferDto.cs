using Domain.Entity;

namespace Domain.Dto
{
    public class AccountTransferDto
    {
        public Account Origin { get; set; }
        public Account Destination { get; set; }
    }
}
