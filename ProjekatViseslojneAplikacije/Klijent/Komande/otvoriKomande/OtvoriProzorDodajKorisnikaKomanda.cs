using Klijent.View.ViewKorisnika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klijent.Komande.otvoriKomande
{
    public class OtvoriProzorDodajKorisnikaKomanda : KlijentKomanda
    {
        public override void Execute(object parameter)
        {
            DodajKorisnikaView prozor = new DodajKorisnikaView();
            prozor.ShowDialog();
        }
        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
