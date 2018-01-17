using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHMB
{
    class JobO
    {
        public int ResourceID { get; set; }
        public int CreatedUserID { get; set; }
        public int Priority { get; set; }
        public string JobName { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime Created { get; set; }
        public DateTime ExeTime { get; set; }
        public int DurationHours { get; set; }
        public override string ToString()
        {
            return string.Format("Name: {0}", JobName);
            //\tPriority: {1}\tResource used: {2}\nDeadline: {3}\tCreated {4} by: {5} , Priority, ResourceID, Deadline, Created, CreatedUserID
        }
    }

}
