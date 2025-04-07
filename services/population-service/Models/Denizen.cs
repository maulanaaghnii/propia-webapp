using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.ComponentModel;

namespace population_service.Models
{
    [Table("tbldenizen")]
    public class Denizen
    {
        [Key]
        [Column(TypeName = "varchar(255)")]
        [JsonPropertyName("id")]
        // [DefaultValue("")]
        public string? Id { get; set; }
        
        [Column("first_name", TypeName = "varchar(255)")]
        [JsonPropertyName("first_name")]
        [DefaultValue("-")]
        public string? FirstName { get; set; }
        
        [Column("last_name", TypeName = "varchar(255)")]
        [JsonPropertyName("last_name")]
        [DefaultValue("-")]
        public string? LastName { get; set; }
        
        [Column("birth_date", TypeName = "varchar(12)")]
        [JsonPropertyName("birth_date")]
        [DefaultValue("0000-00-00")]
        public string? BirthDate { get; set; }

        [Column("birth_time", TypeName = "varchar(6)")]
        [JsonPropertyName("birth_time")]
        [DefaultValue("000000")]
        public string? BirthTime { get; set; }  // HH:MM:SS
        
        [Column("gender", TypeName = "varchar(20)")]
        [JsonPropertyName("gender")]
        [DefaultValue("Other")]
        public string? Gender { get; set; }
        
        [Column("blood_type", TypeName = "varchar(3)")]
        [JsonPropertyName("blood_type")]
        [DefaultValue("-")]
        public string? BloodType { get; set; }

        [Column("eye_color", TypeName = "varchar(3)")]
        [JsonPropertyName("eye_color")]
        [DefaultValue("-")]
        public string? EyeColor { get; set; }

        [Column("handedness", TypeName = "varchar(1)")]
        [JsonPropertyName("handedness")]
        [DefaultValue("-")]
        public string? Handedness { get; set; }

        [Column("is_delete", TypeName = "varchar(1)")]
        [JsonPropertyName("is_delete")]
        [DefaultValue("0")]
        public string? IsDelete { get; set; }
    }
}
