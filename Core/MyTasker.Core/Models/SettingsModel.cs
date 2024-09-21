using MyTasker.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyTasker.Core.Models
{
    public class SettingsModel:BaseModel
    {
        [JsonPropertyName("userName")]
        public string UserName { get; set; }
        [JsonPropertyName("theme")]
        public MyTaskTheme Theme { get; set; }
    }
}
