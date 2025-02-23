using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Play.Common;

namespace Play.Catalog.Service.Entities
{
    public class Items : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)] // Converts Guid to a string in MongoDB

        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public decimal Price { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

    }
}