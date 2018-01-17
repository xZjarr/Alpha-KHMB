using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHMB
{
    class TO
    {
        public double Cost { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public override string ToString()
        {
            return string.Format("Price: {0}\nFrom: {1} to: {2}", Cost, StartTime, EndTime);
        }
    }
}
