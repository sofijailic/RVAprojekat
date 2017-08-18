using Klijent.View.ViewBeleski;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klijent.Komande.otvoriKomande
{
    public class OtvoriProzorDodajBelskuKomanda : KlijentKomanda
    {
        public override void Execute(object parameter)
        {
            DodajBeleskuView prozor = new DodajBeleskuView();
            prozor.ShowDialog();
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
