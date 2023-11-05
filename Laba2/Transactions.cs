using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2
{
    internal class Transactions
    {
        public static List<Transactions> transactions = new List<Transactions>();
        private Guid TransactionID { get; set; }
        private DateTime TransactionDataTime { get; set; }
        private double TotalSum  { get; set; }
        private string OnlineOfline { get; set; }
        private string CashCard { get; set; }
        private bool LoyaltyCard { get; set; }
        private bool Delivery { get; set; }
        public Transactions()
        {
        
        }

        private Transactions(Guid ID, DateTime dateTime, double sum, string status, string typePaymant, bool loyaltyCard, bool delivery)
        {
            TransactionID = ID;
            TransactionDataTime = dateTime;
            TotalSum = sum;
            OnlineOfline = status;
            CashCard = typePaymant;
            LoyaltyCard = loyaltyCard;
            Delivery = delivery;
        }

        public void AddTransaction(Guid ID, DateTime dateTime, double sum, string status, string typePaymant, bool loyaltyCard, bool delivery)
        {
            transactions.Add(new Transactions(ID, dateTime, sum, status, typePaymant, loyaltyCard, delivery));
        }

        public List<Transactions> GetTransactions()
        {
            return transactions;
        }
    }
}
