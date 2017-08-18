using Client.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Command.OtvoriProzorKomande
{
    public class OtvoriProzorDodajKorisnikaCommand :ClientCommand
    {
        public override void Execute(object parameter)
        {
            DodajNovogKorisnikaView prozorDodajKorisnika = new DodajNovogKorisnikaView();
            prozorDodajKorisnika.ShowDialog();
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
