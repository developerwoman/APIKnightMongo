using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIKnightMongo.Entities
{
    [Table("Knights")]
    public class Knight
    {
        [NotMapped]
        [JsonIgnore]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string KnightId { get; set; }
        public string AttributeId { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public DateTime Birthday { get; set; }
        [JsonIgnore]
        public int Age { get; set; }
        public string KeyAttribute { get; set; }
        public List<BsonDocument> KnightWeapon { get; set; } = new List<BsonDocument>();
        public Attribute Attribute { get; set; }
    }
}
