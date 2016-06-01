using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.Services;
using Model;

namespace Bl
{
    public class Process
    {
        private ExpeditionService _expeditionService;
        private MeteorService _meteorService;

        public Process()
        {
            _expeditionService = new ExpeditionService();
            _meteorService = new MeteorService();
        }

        public List<GeneralReportItem> CalculateGeneralReport(int expeditionId, string source)
        {
            var generalReportItems = new List<GeneralReportItem>();
            var expedition = _expeditionService.Get(expeditionId);
            foreach (var day in expedition.Days)
            {
                var clearTime = GetClearTimeOfDay(day);
                var generalCount = _meteorService.GetGeneralCountOfMeteorByDay(day);
                var radiantCount = _meteorService.GetRadiantCountOfMeteorByDay(day, source);
                generalReportItems.Add(new GeneralReportItem()
                {
                    Date = day.Date,
                    ClearTime = Math.Round(clearTime,2),
                    GeneralCount = generalCount,
                    RadiantCount = radiantCount
                });
            }
            return generalReportItems;
        }

        public double GetClearTimeOfDay(Day day)
        {
            double clearTime = 0;
            foreach (var interval in day.Intervals)
            {
                var timeBegin = interval.TimeEnd.Subtract(interval.TimeBegin);
                clearTime += timeBegin.TotalHours;
            }
            return clearTime;
        }

        public int GetGeneralCountOfMeteorByDay(Day day)
        {
            var count = 0;
            foreach (var interval in day.Intervals)
            {
                count += interval.Meteors.Count;
            }
            return count;
        }

    }
}
