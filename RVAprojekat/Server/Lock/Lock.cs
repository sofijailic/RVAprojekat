using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Lock
{
    public class Lock
    {
        public static readonly object lockUser = new object();
        public static readonly object lockBeleska = new object();
    }
}
