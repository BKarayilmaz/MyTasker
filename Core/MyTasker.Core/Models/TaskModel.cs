using MyTasker.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyTasker.Core.Models
{
    public class TaskModel :BaseModel
    {
        [JsonPropertyName("title")]

        public string Title { get; set; }
        [JsonPropertyName("content")]

        public string Content { get; set; }
        [JsonPropertyName("taskDate")]

        public DateTime TaskDate { get; set; }
        [JsonPropertyName("isFavorite")]

        public bool IsFavorite { get; set; }
        [JsonPropertyName("status")]

        public MyTaskStatus Status { get; set; }
        [JsonPropertyName("colour")]

        public string Color { get; set; }
    }
}
