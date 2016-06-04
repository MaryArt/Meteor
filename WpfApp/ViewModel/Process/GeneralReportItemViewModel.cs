using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModel.Process
{
    public class GeneralReportItemViewModel
    {
        public DateTime Date { get; set; }

        public string DateStr => Date != DateTime.MinValue? Date.Day + "-" + (Date.AddDays(1).ToShortDateString()): "Всего";

        public double ClearTime { get; set; }

        public int GeneralCount { get; set; }

        public int RadiantCount { get; set; }
    }
}
