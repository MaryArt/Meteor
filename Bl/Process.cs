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
        private IntervalService _intervalService;
        private DayService _dayService;

        public double AngleVelocity5Point { get; set; }

        public double AngleVelocity8Point => Math.Round((AngleVelocity5Point - 0.4)/0.57,2);

        public double AngleVelocity => Math.Round(3.9*Math.Pow(10,AngleVelocity8Point*0.173),2);

        public double Dencity { get; set; }

        public  readonly int EarthRadius = 6371;
        
        /// <summary>
        /// геоцентрическая скорость в км/с
        /// </summary>
        public double GeoCentrVelocity { get; set; }

        /// <summary>
        /// геоцентрическая скорость в км/ч
        /// </summary>
        public double GeoCentrVelocityKmCh => GeoCentrVelocity*60;

        public Process()
        {
            _expeditionService = new ExpeditionService();
            _meteorService = new MeteorService();
            _intervalService = new IntervalService();
            _dayService = new DayService();
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
                    ClearTime = Math.Round(clearTime, 2),
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

        /// <summary>
        /// Вычисляем точки графика
        /// </summary>
        /// <param name="expeditionId"></param>
        /// <param name="axisXData"> Звездные величины</param>
        /// <param name="axisYData">Количество метеоров данной звездной</param>
        public void CalculateMagnitudeChart(int expeditionId, out int[] axisXData, out int[] axisYData)
        {
            var expedition = _expeditionService.Get(expeditionId);

            var magnitudes = (from day in expedition.Days from interval in day.Intervals from meteor in interval.Meteors select (int)Math.Round(meteor.AverageMagnitude)).ToList();
            var max = magnitudes.ToArray().Max();
            var min = magnitudes.ToArray().Min();
            var n = max - min + 1;
            axisXData = new int[n];
            axisYData = new int[n];

            for (int i = 0; i < n; i++)
            {
                axisXData[i] = min + i;
                axisYData[i] = 0;
            }

            int[] dataY = axisYData;
            int[] dataX = axisXData;
            magnitudes.ForEach(x =>
            {
                for (int i = 0; i < n; i++)
                {
                    if(x == dataX[i]) dataY[i]++;
                }
            });
            axisYData = dataY;
        }

        public double GetAreaOfMeteorZone(double h)
        {
            double alpha = 30;
            double а = (alpha/2)*Math.PI/180;
            double s = Math.PI*h*h*Math.Pow(Math.Tan(а), 2);
            return Math.Round(s,2);
        }

        public double GetDencityOfMeteorShower(int id, double h, double m, int z, string source)
        {
            //var interval = _intervalService.GetInterval(intervalId);
            var expedition = _expeditionService.Get(id);
            double FGeneral = 0;
            double s = GetAreaOfMeteorZone(h);

            int i = 0; //счетчик интервалов участвующих в расчете
            foreach (var day in expedition.Days)
            {
                foreach (var interval in day.Intervals)
                {
                    
                    var T = interval.TimeEnd.Subtract(interval.TimeBegin).TotalHours;
                    if (T == 0) continue;
                    double ZRadiant = 50; //TODO: зенитное радианта надо брать из обекта State для интервала
                    double cosZ = Math.Cos(ZRadiant * Math.PI / 180);

                    int N = _meteorService.GetCount(interval.Id, m, z, source);
                    double FInterval = N / (s * cosZ * T);
                    i++;
                    FGeneral += FInterval;

                }
            }
            FGeneral = FGeneral/i; //среднее арифметическое
            return Math.Round(FGeneral, 6);

        }

        //через отношение длина/продолжительность
        //public double GetAngleVelocity(int id, int m, int Z, string source)
        //{
        //    double w = 0;
        //    var meteors = _meteorService.GetMeteorsByExpeditionId(id);
        //    if (meteors.Count == 0) return 0; //TODO:сообщить что нет метеоров в этой экспедиции
        //    var FilterMeteors = meteors.Where(x => x.AverageMagnitude < m && x.Zenit < Z && x.Source.Equals(source)).ToList();
        //    //var meteors =
        //    //    _meteorService.GetMeteorByPredicate(
        //    //        x => x.AverageMagnitude < m && x.Zenit < Z && x.Source.Equals(source) && x.Interval.Day.Expedition.Id == id);
        //    var warr = new double[FilterMeteors.Count];
        //    int i = 0;
        //    foreach (var meteor in FilterMeteors)
        //    {
        //        warr[i] = meteor.Length/ meteor.Duration;
        //        w += warr[i];
        //        i++;
        //    }
        //    w /= warr.Length; 
        //    return Math.Round(w,2);
        //}

        public double GetAngleVelocity(int id, int m, int Z, string source)
        {
            double w = 0;
            var meteors = _meteorService.GetMeteorsByExpeditionId(id);
            if (meteors.Count == 0) return 0; //TODO:сообщить что нет метеоров в этой экспедиции
            var FilterMeteors = meteors.Where(x => x.AverageMagnitude < m && x.Zenit < Z && x.Source.Equals(source)).ToList();
            
            var warr = new double[FilterMeteors.Count];
            int i = 0;
            foreach (var meteor in FilterMeteors)
            {
                warr[i] = meteor.Speed;
                w += warr[i];
                i++;
            }
            w /= warr.Length;
            return Math.Round(w, 2);
        }

        public double GetGeoCentrVelocity(double angleVelocity)
        {
            double v = 0;
            v = -0.01*angleVelocity*angleVelocity + 1.68*angleVelocity - 4.69;
            return Math.Round(v, 2);
        }

        public double GetSpaceDencity(double dencity, double geoVelosity)
        {
            return Math.Round(dencity/geoVelosity,6);
        }

        public double GetFrequency(int id, double delta, double t)
        {
            var exp = _expeditionService.Get(id);
            double frequency = 0;

            int i = 0; //счетчик дней учитанных в расчете
            foreach (var day in exp.Days)
            {
                var N = _dayService.GetCountOfMeteorByDay(day.Id);
                var T = _dayService.GetClearTimeByDay(day.Id);
                if (T == 0) continue;
                double ZRadiant = 50; //TODO: зенитное радианта надо брать из обекта State для интервала
                double cosZ = Math.Cos(ZRadiant * Math.PI / 180);
                var frequencyDay = N/(T*cosZ);
                i++;
                frequency += frequencyDay;
            }
            frequency = frequency/i;
            return frequency;
        }

        public double GetAbsoluteMagnitude(int id, double h)
        {
            var meteors = _meteorService.GetMeteorsByExpeditionId(id);
            double m0General = 0;
            foreach (var meteor in meteors)
            {
                double ZRadiant = 50; //TODO: зенитное радианта надо брать из обекта State для интервала
                double sinZ = Math.Sin(ZRadiant * Math.PI / 180);
                double cosZ = Math.Cos(ZRadiant * Math.PI / 180);
                var r = Math.Sqrt(Math.Pow(EarthRadius + h, 2) - EarthRadius*EarthRadius*sinZ*sinZ) + EarthRadius*cosZ;
                var m0 = meteor.AverageMagnitude - 10 + 5*Math.Log10(r) + 0.2/cosZ;
                m0General += m0;
            }
            m0General = m0General/meteors.Count;
            return m0General;
        }



    }
}
