using Klijent.Komande.BeleskaKomande;
using Klijent.Komande.otvoriKomande;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Uopsteno;
using Uopsteno.Interfejsi;
using Uopsteno.Klase;

namespace Klijent.ViewModel
{
    public class PocetnaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //beleska
        public IBeleska proxyBeleska;
        public string selektovanaBeleska { get; set; }

        public List<Beleska> listaBeleski { get; set; }
        public List<string> listaBeleskiPrikaz { get; set; }

        //admin
        public string admin { get; set; }

        //direktne
        public ObrisiBeleskuKomanda obrisiB { get; set; }
        public  DuplirajBeleskuKomanda duplirajB{ get; set; }
        public OsveziBeleskuKomanda osveziB{ get; set; }
        public PretraziBeleskeKomanda pretraziB{ get; set; }


        //nedirektne
        public OtvoriProzorDodajKorisnikaKomanda dodajK { get; set; }
        public OtvoriProzorIzmeniPodatkeKorisnikaKomanda izmeniP { get; set; }
        public OtvoriProzorIzmeniGrupeKorisnikaKomanda izmeniG { get;set }
            

        public OtvoriProzorDodajBelskuKomanda dodajB { get; set; }
        public OtvoriProzorIzmeniBeleskuKomanda izmeniB { get; set; }


        public PocetnaViewModel() {

            //admin
            if (Sesija.trenutniKorisnik.Admin)
            {
                admin = "Visible";
            }
            else admin = "Hidden";

            //direktne
            this.obrisiB = new ObrisiBeleskuKomanda(this);
            this.duplirajB = new DuplirajBeleskuKomanda(this);
            this.osveziB = new OsveziBeleskuKomanda(this);
            this.pretraziB = new PretraziBeleskeKomanda(this);

            //nedirektne
            this.dodajK = new OtvoriProzorDodajKorisnikaKomanda();
            this.izmeniP = new OtvoriProzorIzmeniPodatkeKorisnikaKomanda();
            this.izmeniG = new OtvoriProzorIzmeniGrupeKorisnikaKomanda(this);

            this.dodajB = new OtvoriProzorDodajBelskuKomanda();
            this.izmeniB = new OtvoriProzorIzmeniBeleskuKomanda(this);

            //konekcija sa serverom
            NetTcpBinding binding = new NetTcpBinding();
            binding.TransactionFlow = true;
            ChannelFactory<IBeleska> factory = new ChannelFactory<IBeleska>(binding, new EndpointAddress("net.tcp://localhost:51000/BeleskaConnection"));
            proxyBeleska = factory.CreateChannel();

            OsveziPocetnu();
        }

        public void OsveziPocetnu()
        {
            listaBeleski = proxyBeleska.uzmiBeleskeOdKorisnika(Sesija.trenutniKorisnik);

            listaBeleskiPrikaz = new List<string>();
            foreach (Beleska beleska in listaBeleski)
            {
                listaBeleskiPrikaz.Add(beleska.Id + "-" + beleska.Naslov + " (" + beleska.Grupe.Substring(1) + ") ");
            }
            OnPropertyChanged(new PropertyChangedEventArgs("listaBeleskiPrikaz"));
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
