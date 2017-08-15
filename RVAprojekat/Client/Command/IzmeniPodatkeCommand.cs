using Client.ViewModel;
using Common;
using Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.Command
{
    public class IzmeniPodatkeCommand : ClientCommand
    {

        public IzmeniPodatkeViewModel model;
        public IzmeniPodatkeCommand(IzmeniPodatkeViewModel mod) {
            this.model = mod;

        }
        public override void Execute(object parameter)
        {
            if (parameter == null ||
                !(parameter is Object[]))
            {
                MessageBox.Show("Parametri koje ste uneli nisu dobri", "Neuspeh");
                return;
            }

            Object[] parameters = parameter as Object[];
            if (parameters == null || parameters.Length != 3)
            {
                MessageBox.Show("Parametri koje ste uneli nisu dobri", "Neuspeh");
                return;
            }


            foreach (var v in parameters)
            {
                if (v == null || v.ToString().Length == 0)
                {
                    MessageBox.Show("Parametri koje ste uneli nisu dobri", "Neuspeh");
                    return;
                }
            }

            bool uspesno = model.proxyKorisnik.IzmeniPodatke(new User()
            {
                Username = parameters[0].ToString(),
                Ime = parameters[1].ToString(),
                Prezime = parameters[2].ToString()
            });

            if (uspesno)
            {
                MessageBox.Show("Izmena korisnika uspesno izvrsena", "Uspeh");
                model.prozor.Close();
                Sesija.trenutniKorisnik.Ime= parameters[1].ToString();
                Sesija.trenutniKorisnik.Prezime = parameters[2].ToString();
            }
            else MessageBox.Show("Izmena korisnika nije uspela", "Neuspeh");
        }
    }
}
