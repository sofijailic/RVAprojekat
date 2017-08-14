using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Access
{
    public class BeleskaDB : IBeleskaDB
    {
        private static IBeleskaDB myDB;

        public static IBeleskaDB Instance
        {
            get
            {
                if (myDB == null)
                    myDB = new BeleskaDB();

                return myDB;
            }
            set
            {
                if (myDB == null)
                    myDB = value;
            }
        }

        // metode za dodavanje beleske, brisanje, menjanje itd...
    }
}
