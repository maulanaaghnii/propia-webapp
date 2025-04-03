using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace population_service.Models
{
    [Table("tbldenizen")]
    public class Denizen
    {
        [Key]
        [Column(TypeName = "varchar(255)")]
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        
        [Column("first_name", TypeName = "varchar(100)")]
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }
        
        [Column("last_name", TypeName = "varchar(100)")]
        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }
        
        [Column("birth_date", TypeName = "varchar(20)")]
        [JsonPropertyName("birth_date")]
        public string? BirthDate { get; set; }
        
        [Column("gender", TypeName = "varchar(20)")]
        [JsonPropertyName("gender")]
        public string? Gender { get; set; }
        
        [Column("blood_type", TypeName = "varchar(5)")]
        [JsonPropertyName("blood_type")]
        public string? BloodType { get; set; }

        [Column("eye_color", TypeName = "varchar(5)")]
        [JsonPropertyName("eye_color")]
        public string? EyeColor { get; set; }
        
    }
}
