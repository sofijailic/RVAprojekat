using Klijent.View.ViewBeleski;
using Klijent.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Uopsteno;

namespace Klijent.Komande.otvoriKomande
{
    public class OtvoriProzorIzmeniBeleskuKomanda : KlijentKomanda
    {
        public PocetnaViewModel model;
        public OtvoriProzorIzmeniBeleskuKomanda(PocetnaViewModel mod)
        {
            this.model = mod;

        }
        public override void Execute(object parameter)
        {
            string grupe = model.selektovanaBeleska.Split('-')[1].Split('(')[1];
            grupe = grupe.TrimEnd(')');
            string[] listaGrupa = grupe.Split(';');
            bool mozeDaMenja = false;
            foreach (string grupa in listaGrupa)
            {
                if (Sesija.trenutniKorisnik.Grupe.Contains(grupa))
                {
                    mozeDaMenja = true;
                    IzmeniBeleskuView prozor = new IzmeniBeleskuView();
                    prozor.ShowDialog();
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
