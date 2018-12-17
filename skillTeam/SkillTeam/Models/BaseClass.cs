using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SkillTeam.Models
{
    public class BaseClass
    {

        [BsonId()]
        public ObjectId Id { get; set; }
        [BsonElement("description")]
        [BsonRequired()]
        [Required]
        public string Description { get; set; }
    }
}