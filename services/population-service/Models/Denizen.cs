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
        
    }
}
