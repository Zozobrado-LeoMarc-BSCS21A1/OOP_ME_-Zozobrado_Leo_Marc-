namespace ConsoleApp1.Exam
{
    // Encapsulation Example
    public class BankAccount
    {
        public decimal Balance { get; set; }

        public void Deposit(decimal amount)
        {
            Balance = amount;
        }

        public string Withdraw(decimal amount)
        {
            if (Balance > amount)
            {
                Balance = Balance - amount;
            }
            return "Insufficient funds.";
        }

        public void Transfer(BankAccount target, decimal amount)
        {
            if (this.Balance >= amount)
            {
                Withdraw(amount);
                target.Deposit(amount);
            }
        }
    }

}