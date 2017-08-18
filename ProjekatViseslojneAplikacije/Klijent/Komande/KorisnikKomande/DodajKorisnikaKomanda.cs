using Klijent.ViewModel.ViewmModelKorisnika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Uopsteno.Klase;

namespace Klijent.Komande.KorisnikKomande
{
    public class DodajKorisnikaKomanda : KlijentKomanda
    {
        public DodajKorisnikaViewModel model;

        public DodajKorisnikaKomanda(DodajKorisnikaViewModel mod) {
            this.model = mod;
        }

        public override void Execute(object parameter)
        {
            if (parameter == null ||
                !(parameter is Object[]))
            {
                MessageBox.Show("Parametri koje ste uneli nisu odgovarajuci", "Neuspeh");
                return;
            }

            Object[] parameters = parameter as Object[];
            if (parameters == null || parameters.Length != 7)// promeniti, kad dodam grupe 
            {
                MessageBox.Show("Parametri koje ste uneli nisu odgovarajuci", "Neuspeh");
                return;
            }


            foreach (var p in parameters)
            {
                if (p == null || p.ToString().Length == 0)
                {
                    MessageBox.Show("Parametri koje ste uneli nisu odgovarajuci", "Neuspeh");
                    return;
                }
            }

            string grupe = "nijedna";
            if ((bool)parameters[4] == true)
            {
                grupe += ";Politika";
            }
            if ((bool)parameters[5] == true)
            {
                grupe += ";Zabava";
            }
            if ((bool)parameters[6] == true)
            {
                grupe += ";Sport";
            }

            bool uspesno = model.proxyKorisnik.dodajKorisnika(new Korisnik()
            {
                Username = parameters[0].ToString(),
                Ime = parameters[2].ToString(),
                Prezime = parameters[3].ToString(),
                Password = parameters[1].ToString(),
                Admin = false,
                Grupe = grupe
            });

            if (uspesno)
            {
                MessageBox.Show("Uspesno dodat korisnik " + parameters[0].ToString(), "Uspeh");
                model.prozor.Close();
            }
            else
            {
                MessageBox.Show("Korisnicko ime vec je zauzeto od strane drugog korisnika", "Neuspeh");
                return;
            }

        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
