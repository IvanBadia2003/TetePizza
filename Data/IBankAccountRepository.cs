using BankApp.Models;

namespace BankApp.Data
{
    public interface IBankAccountRepository
    {
        void AddAccount(Pizza account);
        Pizza GetAccount(string accountNumber);
        void UpdateAccount(Pizza account);
        void SaveChanges();   

        List<Ingrediente> GetTransactionsByAccount(string accountNumber);

    }
}
