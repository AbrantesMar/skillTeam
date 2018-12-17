using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace SkillTeam.Models
{
    public class Employee : BaseClass
    {
        [BsonElement("skills")]
        public List<Skill> Skills { get; set; }
    }
}