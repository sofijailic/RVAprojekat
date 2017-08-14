using Client.ViewModel;
using Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.Command
{
    class DodajNovogKorisnikaCommand : ClientCommand
    {

        private DodajKorisnikaViewModel dodajModel;
        public DodajNovogKorisnikaCommand(DodajKorisnikaViewModel dodajKViewModel) {

            this.dodajModel = dodajKViewModel;
        }
        public override void Execute(object parameter)
        {
            if (parameter == null ||
                !(parameter is Object[]))
            {
                MessageBox.Show("Uneti parametri nisu validni", "Neuspeh");
                return;
            }

            Object[] parameters = parameter as Object[];
            if (parameters == null || parameters.Length != 4)// promeniti, kad dodam grupe 
            {
                MessageBox.Show("Uneti parametri nisu validni", "Neuspeh");
                return;
            }


            foreach (var v in parameters)
            {
                if (v == null || v.ToString().Length == 0)
                {
                    MessageBox.Show("Uneti parametri nisu validni", "Neuspeh");
                    return;
                }
            }

            bool success = dodajModel.proxyKorisnik.DodajKorisnika(new User()
            {
                Username = parameters[0].ToString(),
                Ime = parameters[2].ToString(),
                Prezime = parameters[3].ToString(),
                Password = parameters[1].ToString(),
                Admin = false,
                Grupe = ""
            });

            if (success)
            {
                MessageBox.Show("Uspesno dodat korisnik " + parameters[0].ToString(), "Uspeh");
                dodajModel.prozor.Close();
            }
            else
            {
                MessageBox.Show("Korisnik sa ovim username-om vec postoji", "Neuspeh");
                return;
            }
        
    }
    }
}
