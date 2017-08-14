using Client.Command.OtvoriProzorKomande;
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    class PocetnaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string admin { get; set; }
        public OtvoriProzorDodajKorisnikaCommand otvoriDodaj { get; set; }
        public otvoriProzorDodajBeleskuCommand otvoriProzorDodajBelesku { get; set; }

        public PocetnaViewModel() {

            if (Sesija.trenutniKorisnik.Admin)
            {
                admin = "Visible";
            }
            else admin = "Hidden";



            this.otvoriDodaj = new OtvoriProzorDodajKorisnikaCommand();
            this.otvoriProzorDodajBelesku = new otvoriProzorDodajBeleskuCommand();
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
}
