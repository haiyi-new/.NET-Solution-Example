using BankLibrary;
namespace MyBank;

class Program
{
    static void Main(string[] args)
    {
        // // Start Humanizer (this one test singular, if yes it can become plural)
        // Console.WriteLine("car".Pluralize());
        // Console.WriteLine("pant".Pluralize());
        // Console.WriteLine("octopus".Pluralize());
        // // Humanizer change number to words
        // Console.WriteLine(3501.ToWords());

        var account = new BankAccount("Haiyi", 10000);
        Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}.");

        account.MakeWithdrawal(100, DateTime.Now, "Mousepad");
        Console.WriteLine($"Your Balance is {account.Balance}");

        // Test for a negative balance: 
        try
        {
            account.MakeWithdrawal(75000, DateTime.Now, "Attempt to Overdraw");
        }

        catch (InvalidOperationException e)
        {
            Console.WriteLine("Exception caught trying to overdraw");
            Console.WriteLine(e.ToString());
        }


        // Test that the initial balances must be positive:
        try
        {
            var invalidAccount = new BankAccount("invalid", -55);
        }

        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine("Exception caught creating account with negative balance");
            Console.WriteLine(e.ToString());
        }

        account.MakeWithdrawal(50, DateTime.Now, "Game");
        account.MakeWithdrawal(5, DateTime.Now, "Coffee");
        account.MakeWithdrawal(5, DateTime.Now, "Diet Coke");
        account.MakeWithdrawal(7, DateTime.Now, "Tea");
        account.MakeWithdrawal(8, DateTime.Now, "Cookie");
        Console.WriteLine($"Your Balance is {account.Balance}");
        Console.WriteLine(account.GetAccountHistory());
    }
}
