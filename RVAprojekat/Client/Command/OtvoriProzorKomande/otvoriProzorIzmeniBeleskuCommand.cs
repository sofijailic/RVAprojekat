using Client.View;
using Client.ViewModel;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.Command.OtvoriProzorKomande
{
    public class otvoriProzorIzmeniBeleskuCommand : ClientCommand
    {

        private PocetnaViewModel model;
        public otvoriProzorIzmeniBeleskuCommand(PocetnaViewModel mod) {
            this.model = mod;

        }
        public override void Execute(object parameter)
        {


            if (model.selektovanaBeleska == null || model.selektovanaBeleska == "")
            {
                MessageBox.Show("Selektujte belesku za izmenu");
                return;
            }

            string grupe = model.selektovanaBeleska.Split('-')[1].Split('(')[1];
            grupe = grupe.Substring(0, (grupe.Length - 2));
            string[] listaGrupa = grupe.Split(';');
            bool mozeDaMenja = false;
            foreach (string grupa in listaGrupa)
            {
                if (Sesija.trenutniKorisnik.Grupe.Contains(grupa))
                {
                    mozeDaMenja = true;
                    IzmeniBeleskuView view = new IzmeniBeleskuView(model);
                    view.ShowDialog();
                    break;
                }
            }
            if (!mozeDaMenja)
            {
                MessageBox.Show("Ne mozete da menjate belesku, jer ne pripadate odgovarajucoj grupi", "Greska");
                return;
            }
        }

        public override void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
