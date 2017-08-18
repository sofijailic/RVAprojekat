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
    public class IzmeniGrupeCommand : ClientCommand
    {
        public IzmeniGrupeKorisnikaViewModel model;
        public IzmeniGrupeCommand(IzmeniGrupeKorisnikaViewModel mod) {
            this.model = mod;
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
            if (parameters == null || parameters.Length != 3)
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

            if ((bool)parameters[0] == false && (bool)parameters[1] == false && (bool)parameters[2] == false)
            {
                MessageBox.Show("Odaberite grupu", "Odaberite grupu");
                return;
            }

            string grupe = "nijedna";

            if ((bool)parameters[0] == true)
            {
                grupe += ";Politika";
            }
            if ((bool)parameters[1] == true)
            {
                grupe += ";Zabava";
            }
            if ((bool)parameters[2] == true)
            {
                grupe += ";Sport";
            }


            string selektovanKorisnik = model.selektovanKorisnik;
            bool success = model.proxyKorisnik.promeniGrupe (new User()
            {
                Username = selektovanKorisnik,
                Grupe = grupe
            });

            if (success)
            {
                MessageBox.Show("Uspesno izmenili korisnicke grupe", "Uspeh");
                model.prozor.Close();
            }
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
