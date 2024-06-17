using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIKnightMongo.Entities
{
    [Table("Attributes")]
    public class Attribute
    {
        [NotMapped]
        [JsonIgnore]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string _id { get; set; }
        [BsonElement]
        public int Strength { get; set; }
        [BsonElement]
        public int Dexterity { get; set; }
        [BsonElement]
        public int Constitution { get; set; }
        [BsonElement]
        public int Intelligence { get; set; }
        [BsonElement]
        public int Wisdom { get; set; }
        [BsonElement]
        public int Charism { get; set; }
    }
}
