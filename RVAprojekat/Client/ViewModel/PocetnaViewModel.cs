using Client.Command;
using Client.Command.OtvoriProzorKomande;
using Common;
using Common.Data;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class PocetnaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IBeleskaDB proxyBeleska;
        public string selektovanaBeleska { get; set; }
        public string admin { get; set; }

        public List<Beleska> listaBeleski { get; set; }
        public List<string> listaBeleskiPrikaz { get; set; }

        public List<ClientCommand> UndoHistory { get; set; }
        public List<ClientCommand> RedoHistory { get; set; }




        public OtvoriProzorDodajKorisnikaCommand otvoriDodaj { get; set; }
        public otvoriProzorIzmeniPodatkeCommand otvoriPodatke { get; set; }
        public otvoriProzorIzmeniGrupeKorisnikaCommand otvoriGrupe { get; set; }


        public otvoriProzorDodajBeleskuCommand otvoriProzorDodajBelesku { get; set; }
        public otvoriProzorIzmeniBeleskuCommand otvoriIzmeni { get; set; }


        public UndoCommand undoCommand { get; set; }
        public RedoCommand redoCommand { get; set; }


        public OsveziBeleskuCommand osvezi { get; set; }
        public ObrisiBeleskuCommand obrisi { get; set; }
        public KlonirajBeleskuCommand kloniraj { get; set; }
        public PretragaCommand pretraga { get; set; }



        public PocetnaViewModel() {

            if (Sesija.trenutniKorisnik.Admin)
            {
                admin = "Visible";
            }
            else admin = "Hidden";

            this.undoCommand = new UndoCommand(this);
            this.redoCommand = new RedoCommand(this);


          
            this.RedoHistory = new List<ClientCommand>();
            this.UndoHistory = new List<ClientCommand>();
            

            this.otvoriDodaj = new OtvoriProzorDodajKorisnikaCommand();
            this.otvoriProzorDodajBelesku = new otvoriProzorDodajBeleskuCommand(this);
            this.otvoriIzmeni = new otvoriProzorIzmeniBeleskuCommand(this);
            this.otvoriPodatke = new otvoriProzorIzmeniPodatkeCommand();
            this.otvoriGrupe = new otvoriProzorIzmeniGrupeKorisnikaCommand(this);



            this.osvezi = new OsveziBeleskuCommand(this);
            this.obrisi = new ObrisiBeleskuCommand(this);
            this.kloniraj = new KlonirajBeleskuCommand(this);
            this.pretraga = new PretragaCommand(this);

            NetTcpBinding binding = new NetTcpBinding();
            binding.TransactionFlow = true;
            ChannelFactory<IBeleskaDB> factory = new ChannelFactory<IBeleskaDB>(binding, new EndpointAddress("net.tcp://localhost:51000/BeleskaConnection"));
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
