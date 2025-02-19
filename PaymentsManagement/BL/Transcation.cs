using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsManagement
{

    public class Transaction
    {

        [BsonId]
        public ObjectId ObjectId { get; set; }
        public int  TranscationId { get; set; }
        public int AccountId { get; set; }
        public string Details { get; set; }
        public decimal MoneyOut { get; set; }
        public decimal MoneyIn { get; set; }
        public string Aggrement { get; set; }
        public decimal Amount { get; set; }
        public decimal RemainingAmount { get; set; }
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; }//MoneyIn/MoneyOut
     
        public Transaction(int accountId, decimal amount, decimal remainingAmount, string Detail ,string Aggrements,TransactionType type, DateTime date)
        {
            
            AccountId = accountId;
            Details = Detail;
            Aggrement = Aggrements;
            Amount = amount;
            Type = type;
            if(type == TransactionType.MoneyOut)
            {
                this.MoneyOut = Amount;
            }
            else if(type == TransactionType.MoneyIn)
            {
                this.MoneyIn = Amount;
            }
            Date = date;
            RemainingAmount = remainingAmount;
        }
        public Transaction(int transcationId, int accountId, decimal amount, decimal remainingAmount, string Detail, string Aggrements, TransactionType type, DateTime date)
        {
            this.TranscationId = transcationId;
            AccountId = accountId;
            Details = Detail;
            Aggrement = Aggrements;
            Amount = amount;
            Type = type;
            if (type == TransactionType.MoneyOut)
            {
                this.MoneyOut = Amount;
            }
            else if (type == TransactionType.MoneyIn)
            {
                this.MoneyIn = Amount;
            }
            Date = date;
            RemainingAmount = remainingAmount;
        }
    }
    public enum TransactionType
    {
        MoneyIn,
        MoneyOut
    }

}
