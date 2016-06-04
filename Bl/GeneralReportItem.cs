using System;

namespace Bl
{
    public class GeneralReportItem
    {
        public DateTime Date { get; set; }

        public double ClearTime { get; set; }

        public int GeneralCount { get; set; }

        public int RadiantCount { get; set; }

        public double I
        {
            get { return RadiantCount/(GeneralCount*ClearTime); }
            set { }
        }

        /// <summary>
        /// доля облачности в поле зрения
        /// </summary>
        public double k { get; set; }

        /// <summary>
        /// поправка на облачность
        /// </summary>
        public double F { get; set; }

        /// <summary>
        /// средняя предельная наблюдателей
        /// </summary>
        public double Mlim { get; set; }

        /// <summary>
        /// зенитное радианта Персеид 
        /// </summary>
        public double ZR { get; set; }

        /// <summary>
        /// косинус зенитного радианта Персеид
        /// </summary>
        public double cosZR { get; set; }

        /// <summary>
        /// Зенитное часовое число
        /// </summary>
        public double ZHR { get; set; }
    }
}
