using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsManagement
{
    
        public class Client
        {
            [BsonId]
            public ObjectId ObjectId { get; set; }
            public int UniqueId { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string PhoneNumber { get; set; }
            public string Type{ get; set; }//Client/Personal/Bank Account
            public string Status{ get; set; }//Active/InActive

            public Client(string name, string address, string phoneNumber, string type)
            {
                Name = name;
                Address = address;
                PhoneNumber = phoneNumber;
                Type = type;
                Status = "Active";
            }

            public override string ToString()
            {
                return $"Client: {ObjectId}, {Name}, {Address}, {PhoneNumber}";
            }
        }
    
}
