using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PaymentsManagement
{
    public class Account
    {

        [BsonId]
        public ObjectId ObjectId { get; set; }
        public int ClientId { get; set; }
        
        public string  ClientName { get; set; }
        public decimal Balance { get; set; }
        public string  Type { get; set; }//Client/Personal/Bank Account



        public Account(int clientId,string clientName, string type)
        {

            ClientId = clientId;
            ClientName = clientName;
            Balance = 0;
            Type = type;
        }
    }
}
