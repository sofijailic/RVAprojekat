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
    public class IzmeniBeleskuCommand : ClientCommand
    {
        public IzmeniBeleskuViewModel model;
        public IzmeniBeleskuCommand(IzmeniBeleskuViewModel mod) {
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
            if (parameters == null || parameters.Length != 6)
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

            if ((bool)parameters[2] == false && (bool)parameters[3] == false && (bool)parameters[4] == false)
            {
                MessageBox.Show("Odaberite grupu", "Odaberite grupu");
                return;
            }

            string grupe = "";
            if ((bool)parameters[2] == true)
            {
                grupe += ";Politika";
            }
            if ((bool)parameters[3] == true)
            {
                grupe += ";Zabava";
            }
            if ((bool)parameters[4] == true)
            {
                grupe += ";Sport";
            }

            bool uspesno = model.proxyBeleska.izmeniBelesku(new Beleska()
            {
                Id = Int32.Parse(parameters[5].ToString()),
                Naslov = parameters[0].ToString(),
                Sadrzaj = parameters[1].ToString(),
                Grupe = grupe
            });

            if (uspesno)
            {
                MessageBox.Show("Beleska uspesno izmenjena", "Uspeh");
                model.proz.Close();
              
            }
            else MessageBox.Show("Beleska neuspesno izmenjena", "Neuspeh");
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
