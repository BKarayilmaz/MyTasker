using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyTasker.Core.Models
{
    public class BaseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; }
        [JsonPropertyName("updatedDate")]
        public DateTime UpdatedDate { get; set; }
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }
    }
}
