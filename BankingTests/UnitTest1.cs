using BankLibrary;

namespace BankingTests;

public class BasicTests
{
    [Fact]
    public void Test1()
    {
        Assert.True(true);
    }
    
    
    [Fact]
    public void Test2()
    {
        var account = new BankAccount("Haiyi", 10000);

        Assert.Throws<InvalidOperationException>(
        // Action  TestCode 
            () => account.MakeWithdrawal(75000, DateTime.Now, "Attempt to Overdraw")
        );
 
    }

    [Fact]
    public void Test3()
    {
        var account = new BankAccount("Haiyi", 10000);

        Assert.Throws<InvalidOperationException>(
        // Action  TestCode 
            () => account.MakeWithdrawal(11800, DateTime.Now, "Attempt to Overdraw")
        );
 
    }

    [Fact]
    public void Test4()
    {
        Assert.Throws<ArgumentOutOfRangeException>(
        // Action  TestCode 
            () => new BankAccount("Invalid", -1000)
        );
 
    }



}