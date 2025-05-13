using MongoDB.Bson.Serialization.Attributes;

namespace Todo.Infrastructure.Mongo.Models
{
    public class MongoAccount
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("account_holder")]
        public string AccountHolder { get; set; } = string.Empty;
        
        [BsonElement("account_type")]
        public string AccountType { get; set; } = string.Empty;
        
        [BsonElement("balance")]
        public decimal Balance { get; set; }

        [BsonElement("transfers_completed")]
        public string[]? TransfersCompleted { get; set; }
    }
}
