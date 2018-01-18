using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHMB
{
    class JobO
    {
        public int JobID { get; set; }
        public int ResourceID { get; set; }
        public int CreatedUserID { get; set; }
        public int Priority { get; set; }
        public string JobName { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime Created { get; set; }
        public DateTime ExeTime { get; set; }
        private int durationHours;
        public int DurationHours
        {
            get { return durationHours; }
            set
            {
                if (value <= 24)
                {
                    durationHours = value;
                }
            }
        }


        public override string ToString()
        {
            return string.Format("Name: {0}", JobName);
        }
    }

}
