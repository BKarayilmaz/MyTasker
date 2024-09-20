using MyTasker.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTasker.Core.Models
{
    public class SettingsModel:BaseModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public MyTaskTheme Theme { get; set; }
    }
}
