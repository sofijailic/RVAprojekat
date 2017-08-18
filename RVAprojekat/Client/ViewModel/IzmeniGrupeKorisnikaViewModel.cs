using Client.Command;
using Client.Command.OtvoriProzorKomande;
using Client.View;
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
    public class IzmeniGrupeKorisnikaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IzmeniGrupeKorisnikaView prozor { get; set; }
        public IzmeniGrupeCommand izmeniGrupuKomanda { get; set; }
        public string selektovanKorisnik { get; set; }

        public List<string> listaKorisnika { get; set; }
        public IUserDB proxyKorisnik;


        public IzmeniGrupeKorisnikaViewModel(IzmeniGrupeKorisnikaView proz) {

            this.prozor = proz;
            this.izmeniGrupuKomanda = new IzmeniGrupeCommand(this);
            this.listaKorisnika = new List<string>();

            NetTcpBinding binding = new NetTcpBinding();
            binding.TransactionFlow = true;
            ChannelFactory<IUserDB> factory = new ChannelFactory<IUserDB>(binding, new EndpointAddress("net.tcp://localhost:50000/UserConnection"));
            proxyKorisnik = factory.CreateChannel();

            List<User> sviKorisnici = proxyKorisnik.uzmiSveKorisnike();
            listaKorisnika = sviKorisnici.Select(x => x.Username).ToList();
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
