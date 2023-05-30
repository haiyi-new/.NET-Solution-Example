using Humanizer;

namespace BankLibrary
{
    public class Transaction
    {
        public decimal Amount { get;}
        public string AmountForHumans 
        {
            get
            {
                return ((int)Amount).ToWords();
            }
        }
        public DateTime Date { get; }
        public string Notes { get; }

        public Transaction(decimal amount, DateTime date, string notes)
        {
            Amount = amount;
            Date = date;
            Notes = notes;
        }

        public void makeTransaction (decimal amount, DateTime date, string notes)
        {

        }
    }
}