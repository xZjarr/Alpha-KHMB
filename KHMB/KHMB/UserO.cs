using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHMB
{
    class UserO
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public bool IsAdmin { get; set; }
        public override string ToString()
        {
            return string.Format("Username: {0}\tFirst name: {1}\tSurname: {2}\nIs Admin: {3}", UserName, FirstName, SurName, IsAdmin);
        }

    }


}
