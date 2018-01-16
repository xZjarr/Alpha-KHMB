using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHMB
{
    class JobO
    {
        public string Resource { get; set; }
        public string CreatedUser { get; set; }
        public int Priority { get; set; }
        string JobName { get; set; }
        DateTime Deadline { get; set; }
        DateTime Created { get; set; }
        public override string ToString()
        {
            return string.Format("Name: {0}\tPriority: {1}\tResource used: {2}\nDeadline: {3}\tCreated {4} by: {5}", JobName, Priority, Resource, Deadline, Created, CreatedUser);
        }
    }

}
