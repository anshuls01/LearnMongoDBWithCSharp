using System.Net;

namespace Todo.Core.Entities
{
    public class Account
    {
        public string  Id { get; set; } = string.Empty;
        public string AccountHolder { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public string[]? TransfersCompleted { get; set; }
    }
}
