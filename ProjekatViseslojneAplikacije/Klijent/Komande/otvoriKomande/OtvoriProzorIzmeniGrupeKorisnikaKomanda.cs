using Klijent.View;
using Klijent.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klijent.Komande.otvoriKomande
{
    public class OtvoriProzorIzmeniGrupeKorisnikaKomanda : KlijentKomanda
    {
        public PocetnaViewModel model;
        public OtvoriProzorIzmeniGrupeKorisnikaKomanda(PocetnaViewModel mod)
        {
            this.model = mod;

        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
