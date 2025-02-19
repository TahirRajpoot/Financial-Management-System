using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PaymentsManagement.DL
{
    public class TranscationDL
    {
        public static List<Transaction> allTranscation = new List<Transaction>();
        public static int TranscationCount = 0;

        public static Transaction getTranscation(int TranscationId)
        {
            foreach (Transaction t in allTranscation)
            {
                if (t.TranscationId == TranscationId)
                {
                    return t;
                }
            }
            return null;
        }
        public static List <Transaction> getTranscationByAccountType(string Type)
        {
            List<Transaction> transcations = new List<Transaction>();
            if (Type == "Client")
            {
                foreach (Transaction a in allTranscation)
                {
                    if (ClientDL.getAccountIds("Client").Contains(a.AccountId))
                    {
                        transcations.Add(a);

                    }
                }

            }
            else if (Type == "Personal")
            {
                foreach (Transaction a in allTranscation)
                {
                    if (ClientDL.getAccountIds("Personal").Contains(a.AccountId))
                    {
                        transcations.Add(a);

                    }
                }
            }
            else if (Type == "Bank Account")
            {
                foreach (Transaction a in allTranscation)
                {
                    if (ClientDL.getAccountIds("Bank Account").Contains(a.AccountId))
                    {
                        transcations.Add(a);

                    }
                }
            }

            return transcations;
        }
        public static void resetAllClientsTranscations()
        {
            List<int> clientIds = ClientDL.getAccountIds("Client");

            foreach (int clientId in clientIds)
            {
                DeleteTransactionsByClientId(clientId);
                AccountDL.UpdateBalanceToZero(clientId);
            }
        }
        public static bool DeleteTransactionsByClientId(int clientId)
        {
            try
            {
                var database = ClientDL.mongoClient.GetDatabase("test");
                var collection = database.GetCollection<BsonDocument>("Transcations");

                var filter = Builders<BsonDocument>.Filter.Eq("AccountId", clientId);

                collection.DeleteMany(filter);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static string loadTranscationsFromDatabase()
        {
            try
            {

                var database = ClientDL.mongoClient.GetDatabase("test");
                var collection = database.GetCollection<Transaction>("Transcations");
                var filter = Builders<Transaction>.Filter.Empty;
                var clientList = collection.Find(filter).ToList();
                allTranscation.AddRange(clientList);
                foreach (var A in allTranscation)
                {
                    if (A.TranscationId > TranscationCount)
                    {
                        TranscationCount = A.TranscationId;
                    }
                }
                return ("Successful" + allTranscation.Count);
            }
            catch (Exception ex)
            {
                return "Error" + ex.Message;
            }

        }
        public static bool addTranscationToList(Transaction T)
        {
            try
            {
                TranscationCount++;
                T.TranscationId = TranscationCount;
                var database = ClientDL.mongoClient.GetDatabase("test");
                var collection = database.GetCollection<BsonDocument>("Transcations");

                var document = new BsonDocument
                {
                    {"TranscationId", T.TranscationId},
                    {"AccountId", T.AccountId},
                    {"Details", T.Details},
                    {"Aggrement", T.Aggrement},
                    {"MoneyOut", T.MoneyOut},
                    {"MoneyIn", T.MoneyIn},
                    {"Amount", T.Amount},
                    {"RemainingAmount", T.RemainingAmount},
                    {"Date", T.Date},
                    {"Type", T.Type}
                };

                collection.InsertOne(document);
                allTranscation.Add(T);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public static void updateRemainingAmount(Transaction n, decimal addition)
        {

            foreach (Transaction t in allTranscation)
            {
                if (t.AccountId == n.AccountId && t.TranscationId > n.TranscationId)
                {
                    t.RemainingAmount = t.RemainingAmount + addition;
                    updateTranscationInDatabase(t);
                }
            }


        }
        public static bool updateTranscationInDatabase(Transaction updatedTransaction)
        {
            try
            {

                var database = ClientDL.mongoClient.GetDatabase("test");
                var collection = database.GetCollection<BsonDocument>("Transcations");

                var filter = Builders<BsonDocument>.Filter.Eq("TranscationId", updatedTransaction.TranscationId);
                var update = Builders<BsonDocument>.Update.Combine(
                    Builders<BsonDocument>.Update.Set("Details", updatedTransaction.Details),
                    Builders<BsonDocument>.Update.Set("MoneyOut", updatedTransaction.MoneyOut),
                    Builders<BsonDocument>.Update.Set("MoneyIn", updatedTransaction.MoneyIn),
                    Builders<BsonDocument>.Update.Set("Aggrement", updatedTransaction.Aggrement),
                    Builders<BsonDocument>.Update.Set("Amount", updatedTransaction.Amount),
                    Builders<BsonDocument>.Update.Set("RemainingAmount", updatedTransaction.RemainingAmount),
                    Builders<BsonDocument>.Update.Set("Date", updatedTransaction.Date),
                    Builders<BsonDocument>.Update.Set("Type", updatedTransaction.Type)

                );
                collection.UpdateOne(filter, update);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static bool EditMoneyOutTranscation(Transaction n, decimal addition)
        {
            if (n.Type == TransactionType.MoneyOut)
            {
                foreach (Transaction t in allTranscation)
                {

                    if (t.TranscationId == n.TranscationId)
                    {
                        t.Amount = n.Amount;
                        t.Aggrement = n.Aggrement;
                        t.Details = n.Details;
                        t.MoneyOut = n.Amount;
                        t.MoneyIn = 0;
                        t.Date = n.Date;
                        t.RemainingAmount = n.RemainingAmount;
                        if (updateTranscationInDatabase(t))
                        {
                            updateRemainingAmount(t, addition);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            else if (n.Type == TransactionType.MoneyIn)
            {
                foreach (Transaction t in allTranscation)
                {

                    if (t.TranscationId == n.TranscationId)
                    {
                        t.Amount = n.Amount;
                        t.Aggrement = n.Aggrement;
                        t.Details = n.Details;
                        t.MoneyIn = n.Amount;
                        t.MoneyOut = 0;
                        t.Date = n.Date;
                        t.Type = n.Type;
                        t.RemainingAmount = n.RemainingAmount;
                        if (updateTranscationInDatabase(t))
                        {
                            updateRemainingAmount(t, addition);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }
        public static bool EditMoneyInTranscation(Transaction n, decimal addition)
        {
            if (n.Type == TransactionType.MoneyOut)
            {
                foreach (Transaction t in allTranscation)
                {

                    if (t.TranscationId == n.TranscationId)
                    {
                        t.Amount = n.Amount;
                        t.Aggrement = n.Aggrement;
                        t.Details = n.Details;
                        t.MoneyOut = n.Amount;
                        t.MoneyIn = 0;
                        t.Type = n.Type;
                        t.Date = n.Date;
                        t.RemainingAmount = n.RemainingAmount;
                        if (updateTranscationInDatabase(t))
                        {
                            updateRemainingAmount(t, addition);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            else if (n.Type == TransactionType.MoneyIn)
            {
                foreach (Transaction t in allTranscation)
                {

                    if (t.TranscationId == n.TranscationId)
                    {
                        t.Amount = n.Amount;
                        t.Aggrement = n.Aggrement;
                        t.Details = n.Details;
                        t.MoneyIn = n.Amount;
                        t.MoneyOut = 0;
                        t.Date = n.Date;
                        t.RemainingAmount = n.RemainingAmount;
                        if (updateTranscationInDatabase(t))
                        {
                            updateRemainingAmount(t, addition);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }
        public static List<Transaction> History(int ClientID, TransactionType transactionType)
        {
            List<Transaction> history = new List<Transaction>();
            foreach (Transaction A in allTranscation)
            {
                if (A.AccountId == ClientID && A.Type == transactionType)
                {
                    history.Add(A);
                }

            }
            return history;
        }
        public static List<Transaction> History(int ClientID)
        {
            List<Transaction> history = new List<Transaction>();
            foreach (Transaction A in allTranscation)
            {
                if (A.AccountId == ClientID)
                {
                    history.Add(A);
                }

            }
            return history;
        }
        public static decimal PaymentReceived(int ClientID)
        {
            decimal total = 0;
            foreach (Transaction A in allTranscation)
            {
                if (A.AccountId == ClientID && A.Type == TransactionType.MoneyIn)
                {
                    total = total + A.Amount;
                }

            }
            return total;
        }
        public static decimal getTotalMoneyOut(int ClientId)
        {
            decimal totalMoneyOut = 0;
            foreach (Transaction t in allTranscation)
            {
                if (t.AccountId == ClientId && t.Type == TransactionType.MoneyOut)
                {
                    totalMoneyOut += t.Amount;
                }
            }
            return totalMoneyOut;
        }
        public static decimal getTotalMoneyOut()
        {
            decimal TOTAL = 0;
            List<int> clientIDs = ClientDL.getAccountIds("Client");
            foreach (Transaction T in allTranscation)
            {
                bool isClient = clientIDs.Contains(T.AccountId);
                if (T.Type == TransactionType.MoneyOut && isClient)
                {
                    TOTAL += T.Amount;
                }
            }
            return TOTAL;
        }
        
        public static decimal getTotalMoneyOutByDate(DateTime dt)
        {
            decimal TOTAL = 0;
            List<int> clientIDs = ClientDL.getAccountIds("Client");
            foreach (Transaction T in allTranscation)
            {
                if(T.Date.Date == dt.Date)
                {
                    bool isClient = clientIDs.Contains(T.AccountId);
                    if (T.Type == TransactionType.MoneyOut && isClient)
                    {
                        TOTAL += T.Amount;
                    }
                }
            }
            return TOTAL;
        }
        public static decimal getTotalMoneyOutPersonal()
        {
            decimal TOTAL = 0;
            List<int> PersonalIDs = ClientDL.getAccountIds("Personal");
            foreach (Transaction T in allTranscation)
            {
                bool isPersonal = PersonalIDs.Contains(T.AccountId);
                if (T.Type == TransactionType.MoneyOut && isPersonal)
                {
                    TOTAL += T.Amount;
                }
            }
            return TOTAL;
        }        
        public static decimal getTotalMoneyOutBankByDate(DateTime dt)
        {
            decimal TOTAL = 0;
            List<int> PersonalIDs = ClientDL.getAccountIds("Bank Account");
            foreach (Transaction T in allTranscation)
            {
                if(T.Date.Date == dt.Date)
                {
                    bool isPersonal = PersonalIDs.Contains(T.AccountId);
                    if (T.Type == TransactionType.MoneyOut && isPersonal)
                    {
                        TOTAL += T.Amount;
                    }
                }
            }
            return TOTAL;
        }
        public static decimal getTotalMoneyOutBank()
        {
            decimal TOTAL = 0;
            List<int> PersonalIDs = ClientDL.getAccountIds("Bank Account");
            foreach (Transaction T in allTranscation)
            {
                
                bool isPersonal = PersonalIDs.Contains(T.AccountId);
                if (T.Type == TransactionType.MoneyOut && isPersonal)
                {
                    TOTAL += T.Amount;
                }
                
            }
            return TOTAL;
        }
        public static decimal getTotalMoneyIn(string Type)
        {
            decimal TOTAL = 0;
            if(Type == "Client")
            {
                List<int> clientIDs = ClientDL.getAccountIds("Client");
                foreach (Transaction T in allTranscation)
                {
                    bool isClient = clientIDs.Contains(T.AccountId);
                    if (T.Type == TransactionType.MoneyIn && isClient)
                    {
                        TOTAL += T.Amount;
                    }
                }
                return TOTAL;
            }
            else if(Type == "Personal")
            {
                List<int> PersonalIDs = ClientDL.getAccountIds("Personal");
                foreach (Transaction T in allTranscation)
                {
                    bool isPersonal = PersonalIDs.Contains(T.AccountId);
                    if (T.Type == TransactionType.MoneyIn && isPersonal)
                    {
                        TOTAL += T.Amount;
                    }
                }
                return TOTAL;
            }
            else if (Type == "Bank Account")
            {
                List<int> BankIDs = ClientDL.getAccountIds("Bank Account");
                foreach (Transaction T in allTranscation)
                {
                    bool isPersonal = BankIDs.Contains(T.AccountId);
                    if (T.Type == TransactionType.MoneyIn && isPersonal)
                    {
                        TOTAL += T.Amount;
                    }
                }
                return TOTAL;
            }
            return TOTAL;
        }
        public static decimal getTotalMoneyInByDate(string Type,DateTime dt)
        {
            decimal TOTAL = 0;
            if (Type == "Client")
            {
                List<int> clientIDs = ClientDL.getAccountIds("Client");
                foreach (Transaction T in allTranscation)
                {
                    if(T.Date.Date == dt.Date)
                    {
                        bool isClient = clientIDs.Contains(T.AccountId);
                        if (T.Type == TransactionType.MoneyIn && isClient)
                        {
                            TOTAL += T.Amount;
                        }
                    }
                }
                return TOTAL;
            }
            else if (Type == "Personal")
            {
                List<int> PersonalIDs = ClientDL.getAccountIds("Personal");
                foreach (Transaction T in allTranscation)
                {
                    if (T.Date.Date == dt.Date)
                    {
                        bool isPersonal = PersonalIDs.Contains(T.AccountId);
                        if (T.Type == TransactionType.MoneyIn && isPersonal)
                        {
                            TOTAL += T.Amount;
                        }
                    }
                }
                return TOTAL;
            }
            else if (Type == "Bank Account")
            {
                List<int> BankIDs = ClientDL.getAccountIds("Bank Account");
                foreach (Transaction T in allTranscation)
                {
                    if (T.Date.Date == dt.Date)
                    {
                        bool isPersonal = BankIDs.Contains(T.AccountId);
                        if (T.Type == TransactionType.MoneyIn && isPersonal)
                        {
                            TOTAL += T.Amount;
                        }
                    }
                }
                return TOTAL;
            }
            return TOTAL;
        }
    }
}
