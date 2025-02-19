using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using static MongoDB.Driver.WriteConcern;
using PaymentsManagement.DL;
using MongoDB.Driver.Core.Configuration;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace PaymentsManagement
{
    public class ClientDL
    {
        
        public static int clientCount = 0;                
        public static string connectionUri = "";
        public static MongoClient mongoClient = new MongoClient(connectionUri);
        private static List<Client> clients = new List<Client>();

        
        public static List<Client> getClientList()
        {
            List<Client> activeClients = new List<Client>();
            foreach (Client client in clients)
            {
                if (client.Status == "Active")
                {
                    activeClients.Add(client);
                }

            }
            return activeClients;
        }
        public static List<int> getClientIds()
        {
            List<int> activeClients = new List<int>();
            foreach (Client client in clients)
            {
                if (client.Status == "Active")
                {
                    activeClients.Add(client.UniqueId);
                }

            }
            return activeClients;
        }
        public static List<int> getAccountIds(string Type)
        {
            List<int> IDs = new List<int>();
            if (Type == "Client")
            {
                foreach (Client a in getClientList())
                {
                    if (a.Type == "Client")
                    {
                        IDs.Add(a.UniqueId);

                    }
                }

            }
            else if (Type == "Personal")
            {
                foreach (Client a in getClientList())
                {
                    if (a.Type == "Personal")
                    {
                        IDs.Add(a.UniqueId);

                    }
                }
            }
            else if (Type == "Bank Account")
            {
                foreach (Client a in getClientList())
                {
                    if (a.Type == "Bank Account")
                    {                       
                        IDs.Add(a.UniqueId);

                    }
                }
            }

            return IDs;
        }

        
       public static string loadClientsFromDatabase()
       {
            try
            {
                
                var database = mongoClient.GetDatabase("test");
                var collection = database.GetCollection<Client>("Clients");
                var filter = Builders<Client>.Filter.Empty; 
                var clientList = collection.Find(filter).ToList();
                clients.AddRange(clientList);
                foreach (var client in clients)
                {
                    if(client.UniqueId > clientCount)
                    {
                        clientCount = client.UniqueId;
                    }
                }               
                return "Successful";
            }
            catch (Exception ex)
            {
                return "Error";
            }
        } 
        
        
        public static List<Client> getBanks()
        {
            List<Client> bankAccounts = new List<Client>();
            foreach (Client a in getClientList())
            {
                if (a.Type == "Bank Account")
                {
                    bankAccounts.Add(a);
                }
            }
            return bankAccounts;
        }
        
        public static List<Client> getPersonalAccounts()
        {
            List<Client> bankAccounts = new List<Client>();
            foreach (Client a in getClientList())
            {
                if (a.Type == "Personal")
                {
                    bankAccounts.Add(a);
                }
            }
            return bankAccounts;
        }                
        

        public static bool addClientToList(Client c)
        {
            try
            {
                clientCount++;
                c.UniqueId = clientCount;
                
                var database = mongoClient.GetDatabase("test");
                var collection = database.GetCollection<BsonDocument>("Clients");

                var document = new BsonDocument
                {
                    {"UniqueId",c.UniqueId},
                    { "Name", c.Name },
                    { "Address", c.Address },
                    { "PhoneNumber", c.PhoneNumber },
                    { "Type", c.Type },
                    { "Status", c.Status }
                };
                collection.InsertOne(document);
                clients.Add(c);
                return true;

            }
            catch
            {
                return false;
            }
        }
        public static bool deleteClient(int ClientId)
        {
            foreach (Client client in clients)
            {
                if (client.UniqueId == ClientId)
                {
                    client.Status = "InActive";
                    if (deleteClientFromDatabase(client.UniqueId))
                    {
                        clients.Remove(client);
                        return true;
                    }

                }
            }
            return false;
        }
        public static bool deleteClientFromDatabase(int UniqueId)
        {
            try
            {

                var database = mongoClient.GetDatabase("test");
                var collection = database.GetCollection<BsonDocument>("Clients");

                var filter = Builders<BsonDocument>.Filter.Eq("UniqueId", UniqueId);


                // Delete the client unconditionally
                collection.DeleteOne(filter);
                var collection2 = database.GetCollection<BsonDocument>("Accounts");

                var filter2 = Builders<BsonDocument>.Filter.Eq("ClientId", UniqueId);
                collection2.DeleteOne(filter2);

                return true;

                


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
       
        

        public static bool updateClient(Client previousClient, Client updatedClient)
        {
            try
            {
                
                clients[clients.IndexOf(previousClient)] = updatedClient;

                
                var database = mongoClient.GetDatabase("test");
                var collection = database.GetCollection<BsonDocument>("Clients");

                var filter = Builders<BsonDocument>.Filter.Eq("UniqueId", previousClient.UniqueId);
                var update = Builders<BsonDocument>.Update.Combine(
                    Builders<BsonDocument>.Update.Set("Name", updatedClient.Name),
                    Builders<BsonDocument>.Update.Set("Address", updatedClient.Address),
                    Builders<BsonDocument>.Update.Set("PhoneNumber", updatedClient.PhoneNumber),
                    Builders<BsonDocument>.Update.Set("Type", updatedClient.Type),
                    Builders<BsonDocument>.Update.Set("Status", updatedClient.Status)
                );

                collection.UpdateOne(filter, update);

               var collection2 = database.GetCollection<BsonDocument>("Accounts");

                var filter1 = Builders<BsonDocument>.Filter.Eq("ClientId", previousClient.UniqueId);
                var update1 = Builders<BsonDocument>.Update.Combine(
                    Builders<BsonDocument>.Update.Set("ClientName", updatedClient.Name),
                    Builders<BsonDocument>.Update.Set("Type", updatedClient.Type)

                );
                collection2.UpdateOne(filter1, update1);
                Account a = AccountDL.getAccount(previousClient.UniqueId);

                AccountDL.clientAccount[AccountDL.clientAccount.IndexOf(a)].ClientName = updatedClient.Name;
                AccountDL.clientAccount[AccountDL.clientAccount.IndexOf(a)].Type = updatedClient.Type;


                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        
        }
        
        public static Client getClient(int ClientID)
        {
            foreach (Client A in getClientList())
            {
                if (A.UniqueId == ClientID)
                {
                    return A;
                }
            }
            return null;
        }
        public static List<Client> searchClient(string searchedText)
        {
            List<Client> clientList = new List<Client>();
            foreach (Client c in getClientList())
            {
                if(c.Type.ToString().ToLower().Contains(searchedText) || c.UniqueId.ToString().ToLower().Contains(searchedText) || c.Name.ToLower().Contains(searchedText) || c.Address.ToLower().Contains(searchedText)|| c.PhoneNumber.ToLower().Contains(searchedText))
                {
                    clientList.Add(c);
                }
            }
            return clientList;
        }

    }
}
