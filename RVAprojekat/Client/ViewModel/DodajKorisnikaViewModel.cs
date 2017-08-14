using Client.Command;
using Client.View;
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
    class DodajKorisnikaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DodajNovogKorisnikaView prozor;

        public IUserDB proxyKorisnik;
        public DodajNovogKorisnikaCommand dodajKor { get; set; }

        public DodajKorisnikaViewModel(DodajNovogKorisnikaView prozorD) {

            this.prozor = prozorD;
            this.dodajKor = new DodajNovogKorisnikaCommand(this);

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
