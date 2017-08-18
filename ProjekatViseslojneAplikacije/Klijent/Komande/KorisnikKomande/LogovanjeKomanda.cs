using Klijent.View;
using Klijent.ViewModel.ViewmModelKorisnika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uopsteno;
using Uopsteno.Klase;

namespace Klijent.Komande.KorisnikKomande
{
    public class LogovanjeKomanda : KlijentKomanda
    {
        private LoginViewModel model;

        public LogovanjeKomanda(LoginViewModel mod) {
            this.model = mod;

        }
        public override void Execute(object parameter)
        {
            if (parameter == null ||
                !(parameter is Object[]))
                return;

            Object[] parameteri = parameter as Object[];
            if (parameteri == null || parameteri.Length != 2)
                return;

            foreach (var p in parameteri)
            {
                if (p == null || p.ToString().Length == 0)
                    return;
            }

            string korisnickoIme = parameteri[0].ToString();
            string lozinka = parameteri[1].ToString();

            Korisnik korisnik = model.proxyKorisnik.ulogujKorisnika(korisnickoIme, lozinka);

            if (korisnik != null)
            {
                Sesija.trenutniKorisnik = korisnik;
                PocetnaView pocetniProzor = new PocetnaView();
                MainWindow.glavni.Close();
                pocetniProzor.ShowDialog();
            }
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
