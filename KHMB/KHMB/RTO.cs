using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHMB
{
    class RTO
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return string.Format("Name: {0}", Name);
        }

    }
}
