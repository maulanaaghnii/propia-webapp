using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace denizen_generator.Models
{
    [Table("tbldenizen")]
    public class Denizen
    {
        [Key]
        [Column(TypeName = "varchar(255)")]
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        
        [Column(TypeName = "varchar(100)")]
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }
        
        [Column(TypeName = "varchar(100)")]
        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }
        
        [Column(TypeName = "varchar(20)")]
        [JsonPropertyName("birth_date")]
        public string? BirthDate { get; set; }
        
        [Column(TypeName = "varchar(20)")]
        [JsonPropertyName("gender")]
        public string? Gender { get; set; }
        
        [Column(TypeName = "varchar(3)")]
        [JsonPropertyName("blood_type")]
        public string? BloodType { get; set; }

        [Column(TypeName = "varchar(3)")]
        [JsonPropertyName("eye_color")]
        public string? EyeColor { get; set; }

        [Column(TypeName = "varchar(3)")]
        [JsonPropertyName("hair_color")]
        public string? HairColor { get; set; }

        [Column(TypeName = "varchar(3)")]
        [JsonPropertyName("skin_color")]
        public string? SkinColor { get; set; }

        [Column(TypeName = "varchar(1)")]
        [JsonPropertyName("handedness")]
        public string? Handedness { get; set; }

    }
}
