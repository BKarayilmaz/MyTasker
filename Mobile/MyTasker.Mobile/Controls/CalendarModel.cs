using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTasker.Mobile.Controls
{
    public class CalendarModel:PropertyChangedModel
    {
        public DateTime Date { get; set; }
        public bool _isCurrentDate;
        public bool IsCurrentDate {
            get => _isCurrentDate;
            set => SetProperty(ref _isCurrentDate, value); }
    }
}
