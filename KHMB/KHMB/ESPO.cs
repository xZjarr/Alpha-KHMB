using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHMB
{
    class ESPO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Double EnergySurplus { get; set; }
        public int ESP_ID { get; set; }
        public override string ToString()
        {
            return string.Format("Energy Surplus: {0}\nStart date: {1:dd/MM/yyyy} Startime: {2}\nEnd date: {3:dd/MM/yyyy}EndTime: {4}", EnergySurplus, StartDate, StartTime.ToString(@"hh\:mm"), EndDate, EndTime.ToString(@"hh\:mm"));
        }
    }
}
