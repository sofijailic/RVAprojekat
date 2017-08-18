using Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Sesija
    {
        public static User trenutniKorisnik = new User();
        public static List<Beleska> listaBeleskiUndo = new List<Beleska>();
        public static List<Beleska> listaBeleskiRedo = new List<Beleska>();
    }
}
