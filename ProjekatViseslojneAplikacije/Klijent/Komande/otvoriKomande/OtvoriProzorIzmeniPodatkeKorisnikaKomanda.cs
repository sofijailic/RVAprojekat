using Klijent.View.ViewKorisnika;
using Klijent.ViewModel;
using Klijent.ViewModel.ViewmModelKorisnika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klijent.Komande.otvoriKomande
{
    public class OtvoriProzorIzmeniPodatkeKorisnikaKomanda : KlijentKomanda
    {

        public IzmeniPodatkeKorisnikaViewModel model;
        public OtvoriProzorIzmeniPodatkeKorisnikaKomanda( )
        {
          

        }

        public override void Execute(object parameter)
        {
            IzmeniPodatkeKorisnikuView prozor = new IzmeniPodatkeKorisnikuView();
            prozor.ShowDialog();
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
