using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace denizen_generator_parser.Models
{
    [Table("tbldenizen_generator_monitoring")]
    public class DenizenGeneratorMonitoring
    {

        [Key]
        [Column("id",TypeName = "varchar(255)")]
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [Column("quantity",TypeName = "varchar(100)")]
        [JsonPropertyName("quantity")]
        public string? Quantity { get; set; }
        
        [Column("start_year",TypeName = "varchar(100)")]
        [JsonPropertyName("start_year")]
        public string? StartYear { get; set; }
        
        [Column("end_year",TypeName = "varchar(20)")]
        [JsonPropertyName("end_year")]
        public string? EndYear { get; set; }
        
        [Column("inserted",TypeName = "varchar(20)")]
        [JsonPropertyName("inserted")]
        public string? Inserted { get; set; }

        [Column("loss",TypeName = "varchar(20)")]
        [JsonPropertyName("loss")]
        public string? Loss { get; set; }

        [Column("timestamps",TypeName = "varchar(20)")]
        [JsonPropertyName("timestamps")]
        public string? Timestamps { get; set; }   

        [Column("status",TypeName = "varchar(20)")]
        [JsonPropertyName("status")]
        public string? Status { get; set; }             
    }
}
