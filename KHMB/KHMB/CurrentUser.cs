﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHMB
{
    class CurrentUser
    {
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static int ID { get; set; }
        public static bool IsAdmin { get; set; }
    }
}
