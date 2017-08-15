using Client.Command;
using Client.View;
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
    public class IzmeniPodatkeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IzmeniPodatkeView prozor { get; set; }
        public IzmeniPodatkeCommand izmeniPod { get; set; }

        public User korisnikZaIzmenu { get; set; }
        public IUserDB proxyKorisnik;

        public IzmeniPodatkeViewModel(IzmeniPodatkeView proz) {
            this.prozor = proz;
            this.izmeniPod = new IzmeniPodatkeCommand(this);
            korisnikZaIzmenu = Sesija.trenutniKorisnik;

            NetTcpBinding binding = new NetTcpBinding();
            binding.TransactionFlow = true;
            ChannelFactory<IUserDB> factory = new ChannelFactory<IUserDB>(binding, new EndpointAddress("net.tcp://localhost:50000/UserConnection"));
            proxyKorisnik = factory.CreateChannel();

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
