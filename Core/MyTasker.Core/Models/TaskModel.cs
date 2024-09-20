using MyTasker.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTasker.Core.Models
{
    public class TaskModel :BaseModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime TaskDate { get; set; }
        public bool IsFavorite { get; set; }
        public MyTaskStatus Status { get; set; }
        public string Color { get; set; }
    }
}
