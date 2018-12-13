using System;
using System.ComponentModel.DataAnnotations;

namespace SkillTeam.Models
{
    public class BaseClass
    {
        public Guid Id { get; set; }
        [Required]
        public string Description { get; set; }
    }
}