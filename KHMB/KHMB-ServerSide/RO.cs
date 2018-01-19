using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHMB_ServerSide
{
    class RO
    {
        public string Name { get; set; }
        public int ResourceID { get; set; }
        public string ExecuteScript { get; set; }

        //List<RTO> rtlist = DB.SelectAllResourceTypes();
        public override string ToString()
        {
            return string.Format("Name: {0}", Name);
        }
    }
}
