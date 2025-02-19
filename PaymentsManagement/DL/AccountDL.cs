using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace PaymentsManagement.DL
{
    public class AccountDL
    {
        public static List<Account> clientAccount = new List<Account>();

        public static decimal getbalance(int ClientId)
        {
            foreach (Account c in clientAccount)
            {
                if (c.ClientId == ClientId)
                {
                    return c.Balance;
                }
            }
            return 0;
        }
        public static List<Account> getBankAndPersonalAccounts()
        {
            List<Account> bankAccounts = new List<Account>();
            List < int > clientIds = ClientDL.getClientIds();
            foreach (Account a in clientAccount)
            {
                if(clientIds.Contains(a.ClientId))
                {
                    if (a.Type == "Bank Account" || a.Type == "Personal")
                    {
                        bankAccounts.Add(a);
                    }
                }
            }
            return bankAccounts;
        }
        public static List<Account> getBankAccounts()
        {
            List<Account> bankAccounts = new List<Account>();
            List<int> clientIds = ClientDL.getClientIds();
            foreach (Account a in clientAccount)
            {
                if (clientIds.Contains(a.ClientId))
                {
                    if (a.Type == "Bank Account")
                    {
                        bankAccounts.Add(a);
                    }
                }
            }
            return bankAccounts;
        }
        public static List<Account> getPersonalAccounts()
        {
            List<Account> bankAccounts = new List<Account>();
            List<int> clientIds = ClientDL.getClientIds();
            foreach (Account a in clientAccount)
            {
                if (clientIds.Contains(a.ClientId))
                {
                    if (a.Type == "Personal")
                    {
                        bankAccounts.Add(a);
                    }
                }
            }
            return bankAccounts;
        }
        public static bool deleteAccount(int ClientId)
        {
            foreach (Account a in clientAccount)
            {
                
                if (a.ClientId == ClientId)
                {
                    clientAccount.Remove(a);
                    return true;    
                }
                
            }
            return false;
        }
        public static bool UpdateBalanceToZero(int accountId)
        {
            try
            {

                var database = ClientDL.mongoClient.GetDatabase("test");
                var collection = database.GetCollection<BsonDocument>("Accounts");

                var filter = Builders<BsonDocument>.Filter.Eq("ClientId", accountId);
                var update = Builders<BsonDocument>.Update.Set("Balance", "0");

                collection.UpdateOne(filter, update);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        public static List<Account> getClientAccounts()
        {
            List<Account> bankAccounts = new List<Account>();
            List<int> clientIds = ClientDL.getClientIds();
            foreach (Account a in clientAccount)
            {
                if (a.Type == "Client" && clientIds.Contains(a.ClientId))
                {
                    bankAccounts.Add(a);
                }
            }
            return bankAccounts;
        }
        public static string loadAccountsFromDatabase()
        {
            try
            {

                var database = ClientDL.mongoClient.GetDatabase("test");
                var collection = database.GetCollection<Account>("Accounts");
                var filter = Builders<Account>.Filter.Empty;
                var clientList = collection.Find(filter).ToList();
                clientAccount.AddRange(clientList);
                return "Successful";
            }
            catch (Exception ex)
            {
                return "Error";
            }

        }
        public static bool addAccountToList(Account a)
        {
            try
            {
                var database = ClientDL.mongoClient.GetDatabase("test");
                var collection = database.GetCollection<BsonDocument>("Accounts");

                var document = new BsonDocument
                {
                    {"ClientId",a.ClientId},
                    { "ClientName", a.ClientName},
                    { "Balance", a.Balance},
                    { "Type", a.Type},

                };
                collection.InsertOne(document);
                clientAccount.Add(a);
                return true;

            }
            catch
            {
                return false;
            }
        }
        public static void calculateBalance(int ClientId)
        {
            decimal MoneyOut = 0;
            decimal MoneyIn = 0;
            foreach (Transaction a in TranscationDL.allTranscation)
            {

                if (a.AccountId == ClientId && a.Type == TransactionType.MoneyOut)
                {
                    MoneyOut = MoneyOut + a.Amount;
                }
                else if (a.AccountId == ClientId && a.Type == TransactionType.MoneyIn)
                {
                    MoneyIn = MoneyIn + a.Amount;
                }
            }
            decimal balance = MoneyIn - MoneyOut;
            foreach (Account a in clientAccount)
            {
                if (a.ClientId == ClientId)
                {
                    a.Balance = balance;
                    updateBalanceInDatabase(a);
                }
            }

        }
        public static void updateBalanceInDatabase(Account a)
        {
            
            var database = ClientDL.mongoClient.GetDatabase("test");
            var collection = database.GetCollection<Account>("Accounts");

            var filter = Builders<Account>.Filter.Eq(x => x.ClientId, a.ClientId);
            var update = Builders<Account>.Update.Set(x => x.Balance, a.Balance);

            var result = collection.UpdateOne(filter, update);


        }
        public static bool MoneyOut(int ClientID, decimal amount, TransactionType tt)
        {
            foreach (Account A in clientAccount)
            {
                if (A.ClientId == ClientID && tt == TransactionType.MoneyOut)
                {
                    A.Balance = A.Balance - amount;
                    updateBalanceInDatabase(A);
                    return true;
                }
                else if (A.ClientId == ClientID && tt == TransactionType.MoneyIn)
                {
                    A.Balance = A.Balance + amount;
                    updateBalanceInDatabase(A);
                    return true;
                }
            }
            return false;
        }
        public static Account getAccount(int ClientID)
        {
            List<int> clientIds = ClientDL.getClientIds();
            foreach (Account A in clientAccount)
            {
                if (A.ClientId == ClientID && clientIds.Contains(A.ClientId))
                {
                    return A;
                }
            }
            return null;
        }
        
        
        
        public static List<Account> searchAccount(string searchedText)
        {
            
            List<Account> AccountList = new List<Account>();
            List<int> activeAccount = ClientDL.getClientIds();
            foreach (Account c in clientAccount)
            {
                if (c.Type == "Client" && activeAccount.Contains(c.ClientId))
                {
                    if (c.Type.ToString().ToLower().Contains(searchedText) || c.ClientId.ToString().ToLower().Contains(searchedText) || c.ClientName.ToLower().Contains(searchedText) || c.Balance.ToString().ToLower().Contains(searchedText))
                    {
                        AccountList.Add(c);
                    }
                }
            }
            return AccountList;
        }
        public static List<Account> searchBankPersonalAccount(string searchedText)
        {
            List<Account> AccountList = new List<Account>();
            List<int> activeAccount = ClientDL.getClientIds();
            foreach (Account c in clientAccount)
            {
                if(c.Type !="Client" && activeAccount.Contains(c.ClientId))
                {
                    if (c.Type.ToString().ToLower().Contains(searchedText) || c.ClientId.ToString().ToLower().Contains(searchedText) || c.ClientName.ToLower().Contains(searchedText) || c.Balance.ToString().ToLower().Contains(searchedText))
                    {
                        AccountList.Add(c);
                    }
                }
            }
            return AccountList;
        }
    }
}
