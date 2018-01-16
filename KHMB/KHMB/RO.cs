using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHMB
{
    class RO
    {
        public string Name { get; set; }

        //List<RTO> rtlist = DB.SelectAllResourceTypes();


        public override string ToString()
        {
            return string.Format("Name: {0}\tResourceType: {1}", Name);
        }
    }
}
