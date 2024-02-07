namespace BankApp.Models;

using System.ComponentModel.DataAnnotations;
using System.Text;

public class Pizza
{
    [Key]
    public string? Number { get; set;}

    [Required]
    public string? Owner { get; set; }

    
    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var item in transactions)
            {
                balance += item.Amount;
            }

            return balance;
        }

    }

    private static int accountNumberSeed = 1;

    public List<Ingrediente> transactions { get; set; } = new List<Ingrediente>();

    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }
        var deposit = new Ingrediente(amount, date, note);
        transactions.Add(deposit);
    }

   public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        }
        if (Balance - amount < 0)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }
        var withdrawal = new Ingrediente(-amount, date, note);
        transactions.Add(withdrawal);
    }

    public Pizza() {}
    public Pizza(string name, decimal initialBalance)
    {
        Owner = name;
        Number = accountNumberSeed.ToString();
        accountNumberSeed++;
        MakeDeposit(initialBalance,DateTime.Now, "Apertura cuenta");
    }

    public override string ToString()
    {
        //return Number ?? "NoNumber";
        var tostring = $"Account {Number} was created for {Owner} with {Balance} initial balance.";
        return tostring;
    }

    public string GetAccountHistory()
    {
        var history = new StringBuilder();

        decimal balance = 0;
        history.AppendLine("Date\t\tAmount\tBalance\tNote");
        foreach (var item in transactions)
        {
            balance += item.Amount;
            history.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Note}");
        }

        return history.ToString();
    }
}