using System.Text;

namespace BankLibrary
{
    public class BankAccount
    {
        private static int accountNumberSeed = 1234567890;

        private List<Transaction> allTransaction = new List<Transaction>();

        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransaction)
                {
                    balance += item.Amount;
                }
                return balance;

            }
        }

        public BankAccount(string name, decimal initialBalance)
        {
            Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
            Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransaction.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withrawal must be positive");
            }

            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Insufficient Balance");
            }

            var withdraw = new Transaction(-amount, date, note);
            allTransaction.Add(withdraw);

        }

        public string GetAccountHistory()
        {
            var report = new StringBuilder();

            // HEADER
            report.AppendLine("Date\t\t\tAmount\tNote");
            foreach (var item in allTransaction)
            {
                // ROWS
                report.AppendLine($"{item.Date}\t{item.AmountForHumans}\t{item.Notes}");
            }
            return report.ToString();
        }
    }
}