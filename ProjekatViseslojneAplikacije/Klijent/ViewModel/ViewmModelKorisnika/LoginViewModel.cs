using Klijent.Komande.KorisnikKomande;
using Klijent.View.ViewKorisnika;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Uopsteno.Interfejsi;

namespace Klijent.ViewModel.ViewmModelKorisnika
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IKorisnik proxyKorisnik;

        public LogovanjeKomanda loginCommand { get; set;}

        public LoginViewModel() {

            this.loginCommand = new LogovanjeKomanda(this);

            NetTcpBinding binding = new NetTcpBinding();
            binding.TransactionFlow = true;
            ChannelFactory<IKorisnik> factory = new ChannelFactory<IKorisnik>(binding, new EndpointAddress("net.tcp://localhost:50000/UserConnection"));
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
